using five.WebApi.Models;
using Refit;

namespace five.WebApi.Interfaces
{
    public interface IProductService
    {
        [Get("/products")]
         Task<Products> GetAllProductsAsync(); 
    }
}
