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
                TempData["message"] = ex.Message;
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

        [HttpPost("/blogs/update")]
        public IActionResult Update([FromForm]TblBlog blog)
        {
            var updateBLog = _blogService.Update(blog.BlogId, blog);
            return RedirectToAction("Index");
            
        }

        [HttpPost("/blogs/delete/{id:int}")]
        public IActionResult Delete([FromRoute]int id)
        {
            var isSuccess = _blogService.Delete(id);
            TempData["isDeleteSuccess"] = isSuccess;
            return RedirectToAction("Index");
        }

     }

   
}
