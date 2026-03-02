using Newtonsoft.Json;
using RestSharp;

namespace Two.MVC.Services;

public class RestClientService
{
    private readonly RestClient _restClient;

    public RestClientService()
    {
        _restClient = new RestClient();
    }

    public async Task<T> SendAsync<T>(string url ,Method method,object? data = null)
    {
        var request = new RestRequest(url, method);
        if(data is not null)
        {
            request.AddJsonBody(data);
        }

        var response = await _restClient.ExecuteAsync(request);

        if (!response.IsSuccessStatusCode)
        {
            return default!;
        }

        var resultStr = response.Content;
        var result = JsonConvert.DeserializeObject<T>(resultStr!);
        return result!;

    }
}
