using ConcurrentObservableCollections.ConcurrentObservableDictionary;
using RentmanSharp.Entity;
using System.Net;
using System.Net.Http.Headers;

namespace RentmanSharp.Endpoint
{
    public abstract class AbstractEndpoint<T>: IEndpoint where T : class , IEntity
    {
        private readonly ILogger<AbstractEndpoint<T>> _logger;
        public abstract string Path { get; }
        public static string? Token { get => Connection.Instance.Token; }
        protected string BaseUrl { get => $"{Constants.API_URL}"; }
        private static string? version { get => Constants.VERSION; }
        private static readonly JsonSerializerOptions serializeOptions = new() { DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull };
        private static readonly JsonSerializerOptions deserializeOptions = new() { PropertyNameCaseInsensitive = true };

        public event EventHandler<DictionaryChangedEventArgs<uint, T>>? EntitiesChanged;

        private HttpClient? httpClient = null;
        public Filter IncrementFilter { get; private set; }

        private ConcurrentObservableDictionary<uint, IEntity> entities { get; } = new(); 

        public ReadOnlyCollection<T> Entities
        {
            get
            {
                return this.entities.Select(d=>d.Value).OfType<T>().ToList().AsReadOnly();
            }
        }

        public AbstractEndpoint()
        {
            _logger = ApplicationLogging.CreateLogger<AbstractEndpoint<T>>();
#pragma warning disable CA2254
            _logger.Log(LogLevel.Debug, $"Initialize {this.GetType().Name}-Endpoint");
#pragma warning restore CA2254
            this.entities.CollectionChanged += Entities_CollectionChanged1;
        }

        private void Entities_CollectionChanged1(object? sender, DictionaryChangedEventArgs<uint, IEntity> e)
        {
            this.EntitiesChanged?.Invoke(this, new DictionaryChangedEventArgs<uint, T>(e.Action,e.Key,(T)e.NewValue, (T)e.OldValue));
        }

        protected virtual Filter? DefaultFilter { get => new(); }

        public async Task<IEntity[]> GetCollectionEntity(Filter? filter = null)
        {
            return (await this.GetCollection(BaseUrl, filter)).OfType<IEntity>().ToArray();
        }
        internal async Task<T[]> GetCollection(string baseUrl, Filter? filter = null)
        {
            baseUrl+=$"/{Path}";
            

            httpClient ??= HttpClientTools.CreateHttpCLient();


            List<IEntity> res= new();
            JsonSerializerOptions options = new() { PropertyNameCaseInsensitive = true };
            Response resp;
            string? url = null;
            bool firstRun = true;
            bool increment = filter is IncrementFilter;
            do
            {
                if (string.IsNullOrWhiteSpace(url))
                    url = baseUrl;
                if (filter == null && this.DefaultFilter != null)
                    filter = this.DefaultFilter;
                else if (filter != null && !firstRun)
                    filter = ((Filter)filter).Next();

                if(increment)
                    url = baseUrl;
                else
                    url = baseUrl + filter;

                if (string.IsNullOrWhiteSpace(url))
                    break;

                resp = await this.PerformGetRequest(url);

                if (filter != null)
                    filter = new Filter(resp, filter.FilterProperties);

                try
                {
                    IEntity[]? list = resp.Data.Deserialize<IEnumerable<T>>(options)?.OfType<IEntity>().ToArray();
                    if (list != null)
                    {
                        res.AddRange(list);
                        foreach (T l in list)
                        {
                            var id = l.ID;
                            entities.AddOrUpdate(id, l, (key, oldValue) =>
                            {
                                if (oldValue is AbstractEntity abstractOldValue && l is AbstractEntity abstractL)
                                {
                                    if (abstractOldValue.updateHash.Equals(abstractL.updateHash))
                                        return abstractL;
                                    return l;
                                }
                                else
                                    return l;
                            });
                        }
                    }
                }
                catch (JsonException e)
                {
                    Console.WriteLine();
                    Console.WriteLine(e);
                    Console.WriteLine(resp.Data.ToString());
                }
                catch (Exception e)
                {
                    Console.WriteLine();
                    Console.WriteLine(e);
                    Console.WriteLine(resp.Data.ToString());
                }
                firstRun = false;
                if (increment)
                    break;
            }
            while (thereIsMore(resp));

            static bool thereIsMore(Response resp)
            {
                return resp.ItemCount == resp.Limit;
            }

            return res.OfType<T>().ToArray();
        }

#pragma warning disable CS8613
        public async Task<IEntity?> GetItemEntity(uint id)
#pragma warning restore CS8613
        {
            return (IEntity?)(await this.GetItem(id));
        }
        public async Task<T?> GetItem(uint id)
        {            
            string url = $"{Constants.API_URL}/{Path}/{id}";
            Response resp = await this.PerformGetRequest(url);
            T? entity = resp.Data.Deserialize<T>(deserializeOptions);
            if (entity == null)
                return default;

            if (!entities.OfType<IEntity>().Any(e => e.ID == ((IEntity)entity).ID))
                entities.AddOrUpdate(((IEntity)entity).ID, entity);

            return entity;
        }
        protected async Task<T?> CreateItemInternal(T item)
        {
            string url = $"{Constants.API_URL}/{Path}";
            Response resp = await this.PerformPutRequest(url, item);
            return resp.Data.Deserialize<T>(deserializeOptions);
        }
        protected async Task<T?> UpdateItemInternal(uint id, T item)
        {
            string url = $"{Constants.API_URL}/{Path}/{id}";
            Response resp = await this.PerformPostRequest(url, item);
            return resp.Data.Deserialize<T>(deserializeOptions);
        }
        protected async Task DeleteItemInternal(uint id)
        {
            string url = $"{Constants.API_URL}/{Path}/{id}";
            await this.PerformDeleteRequest(url);
            return;
        }

        private async Task<Response> PerformGetRequest(string url)
        {
            using var requestMessage = new HttpRequestMessage(HttpMethod.Get, url);
            httpClient ??= HttpClientTools.CreateHttpCLient();
            fillHeader(requestMessage);
            var response = await httpClient.SendAsyncLimited(requestMessage);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                string contentData = await response.Content.ReadAsStringAsync();
                var res = JsonSerializer.Deserialize<Response>(contentData, deserializeOptions);
                return res;
            }
            else
                throw new Exception(response.ToString());
        }
        private async Task<Response> PerformPostRequest(string url, T item)
        {
            using var requestMessage = new HttpRequestMessage(HttpMethod.Post, url);
            httpClient ??= HttpClientTools.CreateHttpCLient();
            fillHeader(requestMessage);
            requestMessage.Content = new StringContent(JsonSerializer.Serialize(item, serializeOptions));
            var response = await httpClient.SendAsyncLimited(requestMessage);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                string contentData = await response.Content.ReadAsStringAsync();
                var res = JsonSerializer.Deserialize<Response>(contentData, deserializeOptions);
                return res;
            }
            else
                throw new Exception(response.ToString());
        }
        private async Task<Response> PerformPutRequest(string url, T item)
        {
            using var requestMessage = new HttpRequestMessage(HttpMethod.Put, url);
            httpClient ??= HttpClientTools.CreateHttpCLient();
            fillHeader(requestMessage);
            requestMessage.Content = new StringContent(JsonSerializer.Serialize(item, serializeOptions));
            var response = await httpClient.SendAsyncLimited(requestMessage);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                string contentData = await response.Content.ReadAsStringAsync();
                var res = JsonSerializer.Deserialize<Response>(contentData, deserializeOptions);
                return res;
            }
            else
                throw new Exception(response.ToString());
        }
        private async Task PerformDeleteRequest(string url)
        {
            using var requestMessage = new HttpRequestMessage(HttpMethod.Delete, url);
            httpClient ??= HttpClientTools.CreateHttpCLient();
            fillHeader(requestMessage);
            var response = await httpClient.SendAsyncLimited(requestMessage);

            if (response.StatusCode == HttpStatusCode.OK)
                return;
            else
                throw new Exception(response.ToString());
        }
        private static void fillHeader(HttpRequestMessage requestMessage)
        {
            if (string.IsNullOrWhiteSpace(Token))
                throw new Exception("Token not set");

            requestMessage.Headers.Add("ContentType", "application/json");
            requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", Token);
            requestMessage.Headers.UserAgent.Add(new ProductInfoHeaderValue("RentmanSharp", version));
        }
    }
}
