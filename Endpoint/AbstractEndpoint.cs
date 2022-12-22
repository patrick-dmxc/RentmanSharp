using RentmanSharp.Entity;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Reflection;
using System.Text;
using System.Text.Json;

namespace RentmanSharp.Endpoint
{
    public abstract class AbstractEndpoint<T>: IEndpoint
    {
        public abstract string Path { get; }
        private static string? token { get => Connection.Instance.Token; }
        private static string? version { get => Constants.VERSION; }
        private static JsonSerializerOptions serializeOptions = new JsonSerializerOptions() { DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull };
        private static JsonSerializerOptions deserializeOptions = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };

        private HttpClient? httpClient = null;

        protected virtual Pagination? DefaultPagination { get; }

        public async Task<IEntity[]> GetCollectionEntity(Pagination? pagination = null)
        {
            return (await this.GetCollection(pagination)).Cast<IEntity>().ToArray();
        }
        public async Task<T[]> GetCollection(Pagination? pagination = null)
        {

            if (pagination == null && this.DefaultPagination != null)
                pagination = this.DefaultPagination;

            if (httpClient == null)
                httpClient = new HttpClient();


            List<T> res= new List<T>();
            string baseUrl = $"{Constants.API_URL}/{Path}";
            JsonSerializerOptions options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
            Response? resp = null;
            string? url = null;
            do
            {
                if (string.IsNullOrWhiteSpace(url))
                    url = baseUrl;

                if (pagination != null)
                    url = baseUrl + ((Pagination)pagination).Next();

                if (string.IsNullOrWhiteSpace(url))
                    break;

                resp = await this.PerformGetRequest(url);

#pragma warning disable CS8604
                pagination = resp;
#pragma warning restore CS8604

                try
                {
#pragma warning disable CS8604
                    var list = await resp.Data.Deserialize<IAsyncEnumerable<T>>(options).ToArrayAsync();
#pragma warning restore CS8604

                    if (list != null)
                        res.AddRange(list);
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
            return resp.Data.Deserialize<T>(deserializeOptions);
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
                    httpClient = new HttpClient();
                fillHeader(requestMessage);
                var response = await httpClient.SendAsync(requestMessage);

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
                    httpClient = new HttpClient();
                fillHeader(requestMessage);
                requestMessage.Content = new StringContent(JsonSerializer.Serialize(item, serializeOptions));
                var response = await httpClient.SendAsync(requestMessage);

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
                    httpClient = new HttpClient();
                fillHeader(requestMessage);
                requestMessage.Content = new StringContent(JsonSerializer.Serialize(item, serializeOptions));
                var response = await httpClient.SendAsync(requestMessage);

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
                    httpClient = new HttpClient();
                fillHeader(requestMessage);
                var response = await httpClient.SendAsync(requestMessage);

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
