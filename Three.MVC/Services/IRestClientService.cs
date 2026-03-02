using RestSharp;

namespace Three.MVC.Services
{
    public interface IRestClientService
    {
        Task<T>? SendAsync<T>(string uri, Method method, object? data = null);
    }
}