using Newtonsoft.Json;
using System.Text;

namespace Two.MVC.Services;

public class HttpClientService
{
    private readonly HttpClient _httpClient;

    public HttpClientService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<T>? SendAsync<T>(string url , HttpMethodEnum method,object? data =null)
    {
        var request = new HttpRequestMessage(new HttpMethod(method.ToString()),url);
        if(data is not null)
        {
            request.Content = new StringContent(JsonConvert.SerializeObject(data, Formatting.Indented),Encoding.UTF8,"application/json");
        }

        var response = await _httpClient.SendAsync(request);
        var resultStr = await response.Content.ReadAsStringAsync();
        var result = JsonConvert.DeserializeObject<T>(resultStr)!;
        return result;
    }
}

public enum HttpMethodEnum
{ 
    GET,
    POST,
    PUT,
    PATCH,
    DELETE
}
