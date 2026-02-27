using Database_02.Models;
using Microsoft.AspNetCore.Mvc;
using Three.WebApi.Services;

namespace One.MVC.Controllers
{
    public class BlogsController : Controller
    {
        private readonly IBlogService _blogService;

        public BlogsController(IBlogService blogService)
        {
            _blogService = blogService;
        }

        public IActionResult Index()
        {
            var blogs = _blogService.GetAll();
            return View(blogs);
        }

        [HttpGet("/blogs/Details/{id:int}")]
        public IActionResult Details([FromRoute]int id)
        {
            var blog = _blogService.GetOne(id);
            return View(blog);
        }

        [ActionName("Create")]
        public IActionResult CreateBlog()
        {
            return View();
        }

        [HttpPost("/blogs/Save")]
        public IActionResult Save([FromForm]TblBlog blog)
        {
            try
            {
                var newVblog = _blogService.Create(blog);
                //return Redirect("/blogs/index");
                TempData["isSuccess"] = true;
                TempData["message"] = "create success";
            }
            catch (Exception ex)
            {
                TempData["isSuccess"] = false;
                TempData["message"] = "create fail";
            }
            return RedirectToAction("Index");
        }

        [HttpGet("/blogs/Edit/{id:int}")]
        public IActionResult Edit([FromRoute]int id)
        {
            var oldBlog = _blogService.GetOne(id);
            ViewBag.oldBlog = oldBlog;
            return View();
        }

        [HttpPut("/blogs/update")]
        public IActionResult Update(TblBlog blog)
        {
            var updateBLog = _blogService.Update(blog.BlogId, blog);
            return RedirectToAction("Index");
            }
        }
}
