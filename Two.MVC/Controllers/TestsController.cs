using Microsoft.AspNetCore.Mvc;
using RestSharp;
using Two.MVC.Models;
using Two.MVC.Services;

namespace Two.MVC.Controllers
{
    public class TestsController : Controller
    {
        private readonly HttpClientService _httpClientService;

        private readonly RestClientService _restClientService;

        public TestsController(HttpClientService httpClientService, RestClientService restClientService)
        {
            _httpClientService = httpClientService;
            _restClientService = restClientService;
        }

        public async Task<IActionResult> Index()
        {
            var url = "https://dummyjson.com/quotes";
           var result = await _httpClientService.SendAsync<Quotes>(url,HttpMethodEnum.GET)!;
            return View(result);
        }

        [HttpGet("/tests/detail/{id}")]
        public async Task<IActionResult> Detail(int id)
        {
            var url = $"https://dummyjson.com/quotes/{id}";
            var result = await _restClientService.SendAsync<Quote>(url, Method.Get);
            return View(result);

        }
    }
}
