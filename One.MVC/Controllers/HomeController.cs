using Microsoft.AspNetCore.Mvc;
using One.MVC.Models;
using System.Diagnostics;

namespace One.MVC.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.age = 33;
            ViewData["country"] = "myanmar";
            return View("Index",new {name="mgmg"});
        }

        public IActionResult Privacy()
        {
            HomeModel model = new HomeModel() { Name = "Home Model"};
            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
