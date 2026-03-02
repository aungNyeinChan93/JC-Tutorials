using Microsoft.AspNetCore.Mvc;
using Two.MVC.Models;
using Two.MVC.Services;

namespace Two.MVC.Controllers
{
    public class TestsController : Controller
    {
        private readonly HttpClientService _httpClientService;

        public TestsController(HttpClientService httpClientService)
        {
            _httpClientService = httpClientService;
        }

        public async Task<IActionResult> Index()
        {
            var url = "https://dummyjson.com/quotes";
           var result = await _httpClientService.SendAsync<Quotes>(url,HttpMethodEnum.GET)!;
            return View(result);
        }
    }
}
