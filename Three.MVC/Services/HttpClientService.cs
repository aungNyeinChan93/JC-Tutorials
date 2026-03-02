using Newtonsoft.Json;
using System.Runtime.InteropServices;
using System.Text;

namespace Three.MVC.Services
{
    public class HttpClientService : IHttpClientService
    {
        private readonly HttpClient _httpClient;

        public HttpClientService(string url)
        {
            _httpClient = new HttpClient() { BaseAddress = new Uri(url) };
        }

        public async Task<T>? SendAsync<T>(string endPoint, HttpClientMethod method, object? data = null)
        {
            var request = new HttpRequestMessage(new HttpMethod(method.ToString()), endPoint);

            if (data is not null)
            {
                request.Content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
            }
            ;

            var response = await _httpClient.SendAsync(request);
            if (!response.IsSuccessStatusCode)
            {
                return default!;
            }
            var resultStr = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<T>(resultStr);
            if (result is null) return default!;
            return result;


        }
    }

    public enum HttpClientMethod
    { 
        GET,
        POST,
        PUT,
        DELETE
    }

}
