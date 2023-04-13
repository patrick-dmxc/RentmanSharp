using ConcurrentObservableCollections.ConcurrentObservableDictionary;
using RentmanSharp.Entity;
using RentmanSharp.Facade;
using System.Net;
using System.Net.Http.Headers;

namespace RentmanSharp.Endpoint
{
    public abstract class AbstractEndpoint<T,K>: IEndpoint where T : class , IEntity where K : class, IFacade
    {
        private readonly ILogger<AbstractEndpoint<T, K>> _logger;
        public abstract string Path { get; }
        public static string? Token { get => Connection.Instance.Token; }
        protected string BaseUrl { get => $"{Constants.API_URL}"; }
        private static string? version { get => Constants.VERSION; }
        private static readonly JsonSerializerOptions serializeOptions = new() { DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull };
        private static readonly JsonSerializerOptions deserializeOptions = new() { PropertyNameCaseInsensitive = true };

        public event EventHandler<DictionaryChangedEventArgs<uint, K>>? EntitiesChanged;

        private HttpClient? httpClient = null;

        private ConcurrentObservableDictionary<uint, K> facades { get; } = new(); 

        public ReadOnlyCollection<K> Facades
        {
            get
            {
                return this.facades.Select(d=>d.Value).OfType<K>().ToList().AsReadOnly();
            }
        }

        public AbstractEndpoint()
        {
            _logger = ApplicationLogging.CreateLogger<AbstractEndpoint<T,K>>();
#pragma warning disable CA2254
            _logger.Log(LogLevel.Debug, $"Initialize {this.GetType().Name}-Endpoint");
#pragma warning restore CA2254
            this.facades.CollectionChanged += Entities_CollectionChanged1;
        }

        private void Entities_CollectionChanged1(object? sender, DictionaryChangedEventArgs<uint, K> e)
        {
            this.EntitiesChanged?.Invoke(this, new DictionaryChangedEventArgs<uint, K>(e.Action,e.Key,e.NewValue, e.OldValue));
        }

        protected virtual Filter? DefaultFilter { get => new(); }

        public async Task<IFacade[]> GetCollectionFacades(Filter? filter = null)
        {
            return (await this.GetCollection(BaseUrl, filter)).OfType<IFacade>().ToArray();
        }
        internal async Task<K[]> GetCollection(string baseUrl, Filter? filter = null)
        {
            baseUrl+=$"/{Path}";            

            httpClient ??= HttpClientTools.CreateHttpCLient();

            List<IFacade> res= new();
            JsonSerializerOptions options = new() { PropertyNameCaseInsensitive = true };
            Response? resp;
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

                if (increment)
                {
                    if (this.DefaultFilter != null)
                        url = baseUrl + new Pagination(this.DefaultFilter.Pagination.Limit, null);
                    else
                        url = baseUrl;
                }
                else
                    url = baseUrl + filter;

                if (string.IsNullOrWhiteSpace(url))
                    break;

                resp = await this.PerformGetRequest(url);

                if (filter != null)
                    filter = new Filter(resp, filter.FilterProperties);

                try
                {
                    IEntity[]? list = resp.Value.Data.Deserialize<IEnumerable<T>>(options)?.OfType<IEntity>().ToArray();
                    if (list != null)
                    {
                        foreach (T l in list)
                        {
                            IFacade? f = await addOrUpdateFacade(l);
                            if (f != null)
                                res.Add(f);
                        }
                    }
                }
                catch (JsonException e)
                {
                    Console.WriteLine();
                    Console.WriteLine(e);
                    Console.WriteLine(resp.Value.Data.ToString());
                }
                catch (Exception e)
                {
                    Console.WriteLine();
                    Console.WriteLine(e);
                    Console.WriteLine(resp.Value.Data.ToString());
                }
                firstRun = false;
                if (increment)
                    break;
            }
            while (thereIsMore(resp.Value));

            static bool thereIsMore(Response resp)
            {
                return resp.ItemCount == resp.Limit;
            }

            return res.OfType<K>().ToArray();
        }
        private async Task<IFacade?> addOrUpdateFacade(T entity)
        {
            try
            {
                AbstractFacade<T>? facade = null;
                if (this.facades.ContainsKey(entity.ID))
                {
                    facade = facades[entity.ID] as AbstractFacade<T>;
                    if (facade != null)
                        await facade.UpdateViaEntity(entity);
                    return facade;
                }
                facade = Activator.CreateInstance(typeof(K)) as AbstractFacade<T>;
                K? k = facade as K;
                if (facade != null)
                    await facade.UpdateViaEntity(entity);
                if (k != null)
                    facades.AddOrUpdate(entity.ID, k);
                return facade;
            }
            catch(Exception e)
            {
                _logger?.LogError(e, string.Empty);
            }
            return null;
        }

#pragma warning disable CS8613
        public async Task<IFacade?> GetItemFacade(uint id)
#pragma warning restore CS8613
        {
            return await this.GetItem(id);
        }
        public async Task<K?> GetItem(uint id)
        {            
            string url = $"{Constants.API_URL}/{Path}/{id}";
            Response? resp = await this.PerformGetRequest(url);
            if (resp.HasValue)
            {
                K? entity = resp.Value.Data.Deserialize<K>(deserializeOptions);
                if (entity == null)
                    return default;

                if (!facades.OfType<IFacade>().Any(e => e.ID == (entity).ID))
                    facades.AddOrUpdate((entity).ID, entity);

                return entity;
            }
            return null;
        }
        protected async Task<T?> CreateItemInternal(T item)
        {
            string url = $"{Constants.API_URL}/{Path}";
            Response? resp = await this.PerformPutRequest(url, item);
            if (resp.HasValue)
                return resp.Value.Data.Deserialize<T>(deserializeOptions);

            return null;
        }
        protected async Task<T?> UpdateItemInternal(uint id, T item)
        {
            string url = $"{Constants.API_URL}/{Path}/{id}";
            Response? resp = await this.PerformPostRequest(url, item);
            if (resp.HasValue)
                return resp.Value.Data.Deserialize<T>(deserializeOptions);
            return null;
        }
        protected async Task DeleteItemInternal(uint id)
        {
            string url = $"{Constants.API_URL}/{Path}/{id}";
            await this.PerformDeleteRequest(url);
            return;
        }

        private async Task<Response?> PerformGetRequest(string url)
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
                _logger?.LogWarning(response.ToString(), url, Environment.StackTrace);
            return null;
        }
        private async Task<Response?> PerformPostRequest(string url, T item)
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
                _logger?.LogWarning(response.ToString(), url, Environment.StackTrace);
            return null;
        }
        private async Task<Response?> PerformPutRequest(string url, T item)
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
                _logger?.LogWarning(response.ToString(), url, Environment.StackTrace);
            return null;
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
                _logger?.LogWarning(response.ToString(), url, Environment.StackTrace);
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
