using Microsoft.AspNetCore.Mvc;
using Three.WebApi.Services;

namespace Two.MVC.Controllers
{
    public class BlogsAjaxController : Controller
    {
        private readonly IBlogService blogService;

        public BlogsAjaxController(IBlogService blogService)
        {
            this.blogService = blogService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetAllBlogs()
        {
            var blogs = blogService.GetAll();
            return Json(blogs);
        }
    }
}
