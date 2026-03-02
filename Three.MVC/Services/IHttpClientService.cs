namespace Three.MVC.Services
{
    public interface IHttpClientService
    {
        Task<T>? SendAsync<T>(string endPoint, HttpClientMethod method, object? data = null);
    }
}