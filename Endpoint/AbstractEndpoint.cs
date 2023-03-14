using ConcurrentObservableCollections.ConcurrentObservableDictionary;
using Microsoft.Extensions.Logging;
using RentmanSharp.Entity;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Net;
using System.Net.Http.Headers;
using System.Text.Json;

namespace RentmanSharp.Endpoint
{
    public abstract class AbstractEndpoint<T>: IEndpoint
    {
        private readonly ILogger<AbstractEndpoint<T>> _logger;
        public abstract string Path { get; }
        private static string? token { get => Connection.Instance.Token; }
        protected string? BaseUrl { get => $"{Constants.API_URL}"; }
        private static string? version { get => Constants.VERSION; }
        private static JsonSerializerOptions serializeOptions = new JsonSerializerOptions() { DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull };
        private static JsonSerializerOptions deserializeOptions = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };

        public event EventHandler<DictionaryChangedEventArgs<uint, T>> EntitiesChanged;

        private HttpClient? httpClient = null;

        private ConcurrentObservableDictionary<uint,T> entities = new ConcurrentObservableDictionary<uint, T>();

        public ReadOnlyCollection<T> Entities
        {
            get
            {
                return this.entities.Select(d=>d.Value).ToList().AsReadOnly();
            }
        }

        public AbstractEndpoint()
        {
            _logger = ApplicationLogging.CreateLogger<AbstractEndpoint<T>>();
            _logger.Log(LogLevel.Debug, $"Initialize {this.GetType().Name}-Endpoint");
            this.entities.CollectionChanged += Entities_CollectionChanged1;
        }

        private void Entities_CollectionChanged1(object? sender, DictionaryChangedEventArgs<uint, T> e)
        {
            this.EntitiesChanged?.Invoke(this, e);
        }

        protected virtual Filter? DefaultFilter { get => new Filter(); }

        public async Task<IEntity[]> GetCollectionEntity(Filter? filter = null)
        {
            return (await this.GetCollection(BaseUrl, filter)).Cast<IEntity>().ToArray();
        }
        internal async Task<T[]> GetCollection(string baseUrl, Filter? filter = null)
        {
            baseUrl+=$"/{Path}";
            

            if (httpClient == null)
                httpClient = HttpClientTools.CreateHttpCLient();


            List<T> res= new List<T>();
            JsonSerializerOptions options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
            Response? resp = null;
            string? url = null;
            bool firstRun = true;
            do
            {
                if (string.IsNullOrWhiteSpace(url))
                    url = baseUrl;
                if (filter == null && this.DefaultFilter != null)
                    filter = this.DefaultFilter;
                else if (filter != null && !firstRun)
                    filter = ((Filter)filter).Next();

                url = baseUrl + filter;

                if (string.IsNullOrWhiteSpace(url))
                    break;

                resp = await this.PerformGetRequest(url);

#pragma warning disable CS8604
                filter = new Filter(resp, filter.FilterProperties);
#pragma warning restore CS8604

                try
                {
#pragma warning disable CS8604
                    var list = await resp.Data.Deserialize<IAsyncEnumerable<T>>(options).ToArrayAsync();
#pragma warning restore CS8604

                    if (list != null)
                    {
                        res.AddRange(list);
                        foreach (IEntity l in list)
                        {
                            if (!entities.OfType<IEntity>().Any(e => e.ID == l.ID))
                                entities.AddOrUpdate(l.ID.Value, (T)l);
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
            }
            while (thereIsMore(resp));

            bool thereIsMore(Response? resp)
            {
                if (resp == null)
                    return false;

                return resp.ItemCount == resp.Limit;
            }

            return res.ToArray();
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
            T entity = resp.Data.Deserialize<T>(deserializeOptions);
            if (!entities.OfType<IEntity>().Any(e => e.ID == ((IEntity)entity).ID))
                entities.AddOrUpdate(((IEntity)entity).ID.Value, entity);

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
            using (var requestMessage = new HttpRequestMessage(HttpMethod.Get, url))
            {
                if (httpClient == null)
                    httpClient = HttpClientTools.CreateHttpCLient();
                fillHeader(requestMessage);
                var response = await httpClient.SendAsyncLimited(requestMessage);

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    string contentData = await response.Content.ReadAsStringAsync();
                    var res = JsonSerializer.Deserialize<Response>(contentData, deserializeOptions);
                    if (res == null)
                        throw new Exception("Can't deserialize Data");
                    return res;
                }
                else
                    throw new Exception(response.ToString());
            }
        }
        private async Task<Response> PerformPostRequest(string url, T item)
        {
            using (var requestMessage = new HttpRequestMessage(HttpMethod.Post, url))
            {
                if (httpClient == null)
                    httpClient = HttpClientTools.CreateHttpCLient();
                fillHeader(requestMessage);
                requestMessage.Content = new StringContent(JsonSerializer.Serialize(item, serializeOptions));
                var response = await httpClient.SendAsyncLimited(requestMessage);

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    string contentData = await response.Content.ReadAsStringAsync();
                    var res = JsonSerializer.Deserialize<Response>(contentData, deserializeOptions);
                    if (res == null)
                        throw new Exception("Can't deserialize Data");
                    return res;
                }
                else
                    throw new Exception(response.ToString());
            }
        }
        private async Task<Response> PerformPutRequest(string url, T item)
        {
            using (var requestMessage = new HttpRequestMessage(HttpMethod.Put, url))
            {
                if (httpClient == null)
                    httpClient = HttpClientTools.CreateHttpCLient();
                fillHeader(requestMessage);
                requestMessage.Content = new StringContent(JsonSerializer.Serialize(item, serializeOptions));
                var response = await httpClient.SendAsyncLimited(requestMessage);

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    string contentData = await response.Content.ReadAsStringAsync();
                    var res = JsonSerializer.Deserialize<Response>(contentData, deserializeOptions);
                    if (res == null)
                        throw new Exception("Can't deserialize Data");
                    return res;
                }
                else
                    throw new Exception(response.ToString());
            }
        }
        private async Task PerformDeleteRequest(string url)
        {
            using (var requestMessage = new HttpRequestMessage(HttpMethod.Delete, url))
            {
                if (httpClient == null)
                    httpClient = HttpClientTools.CreateHttpCLient();
                fillHeader(requestMessage);
                var response = await httpClient.SendAsyncLimited(requestMessage);

                if (response.StatusCode == HttpStatusCode.OK)
                    return;
                else
                    throw new Exception(response.ToString());
            }
        }
        private static void fillHeader(HttpRequestMessage requestMessage)
        {
            if (string.IsNullOrWhiteSpace(token))
                throw new Exception("Token not set");

            requestMessage.Headers.Add("ContentType", "application/json");
            requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            requestMessage.Headers.UserAgent.Add(new ProductInfoHeaderValue("RentmanSharp", version));
        }
    }
}
