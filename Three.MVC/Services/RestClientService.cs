using Newtonsoft.Json;
using RestSharp;

namespace Three.MVC.Services
{
    public class RestClientService : IRestClientService
    {
        private readonly RestClient _restClient;

        public RestClientService(string url)
        {
            this._restClient = new RestClient(url);
        }

        public async Task<T>? SendAsync<T>(string uri, Method method, object? data = null)
        {
            var request = new RestRequest(uri, method);
            if (data is not null)
            {
                request.AddJsonBody(data);
            }

            var response = await _restClient.ExecuteAsync(request);
            if (!response.IsSuccessStatusCode)
            {
                return default!;
            }
            var resultStr = response.Content;
            if (resultStr is null) return default!;
            var result = JsonConvert.DeserializeObject<T>(resultStr);
            if (result is null) return default!;
            return result;
        }
    }
}
