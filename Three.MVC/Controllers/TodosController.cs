using Microsoft.AspNetCore.Mvc;
using RestSharp;
using Three.MVC.Models;
using Three.MVC.Services;

namespace Three.MVC.Controllers
{
    public class TodosController : Controller
    {
        public async Task<IActionResult> Index([FromServices]IHttpClientService httpClientService)
        {
            var todos = await httpClientService.SendAsync<Todos>("/todos",HttpClientMethod.GET)!;
            return View(todos);
        }

        [HttpGet("/todos/view/{id}")]
        public async Task<IActionResult> View(int id,[FromServices]IRestClientService restClientService)
        {
            string uri = $"/todos/{id}";
            var todo =await restClientService.SendAsync<Todo>(uri, Method.Get)!;
            return View(todo);
        }
    }
}
