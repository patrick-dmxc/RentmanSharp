using RentmanSharp.Entity;
using System.Collections.Generic;
using System.Net;
using System.Net.Http.Headers;
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

        private HttpClient? httpClient = null;

        protected virtual Pagination? DefaultPagination { get; }

        public async Task<IEntity[]> GetDataEntity(Pagination? pagination = null)
        {
            return (await this.GetData(pagination)).Cast<IEntity>().ToArray();
        }
        public async Task<T[]> GetData(Pagination? pagination = null)
        {
            if (string.IsNullOrWhiteSpace(token))
                throw new Exception("Token not set");

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

                using (var requestMessage = new HttpRequestMessage(HttpMethod.Get, url))
                {
                    requestMessage.Headers.Add("ContentType", "application/json");
                    requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
                    requestMessage.Headers.UserAgent.Add(new ProductInfoHeaderValue("RentmanSharp", version));

                    var response = await httpClient.SendAsync(requestMessage);

                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        string contentData = await response.Content.ReadAsStringAsync();
                        resp = JsonSerializer.Deserialize<Response>(contentData, options);
                    }
                    else
                        throw new Exception(response.ToString());
                }

#pragma warning disable CS8604 // Mögliches Nullverweisargument.
                pagination = resp;
#pragma warning restore CS8604 // Mögliches Nullverweisargument.

                try
                {
#pragma warning disable CS8604 // Mögliches Nullverweisargument.
                    var list = await resp.Data.Deserialize<IAsyncEnumerable<T>>(options).ToArrayAsync();
#pragma warning restore CS8604 // Mögliches Nullverweisargument.

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

        static string StreamToString(Stream stream)
        {
            using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                return reader.ReadToEnd();
        }
    }
}
