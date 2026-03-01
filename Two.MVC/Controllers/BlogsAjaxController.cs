using Database_02.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks.Dataflow;
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

        public IActionResult Create()
        {
            return View("Create");
        }

        [HttpPost]
        public IActionResult Save(TblBlog blog)
        {
            var b = blogService.Create(blog);
            return Json(b);   
        }
    }
}
