using Database_02.Models;
using Microsoft.AspNetCore.Mvc;
using Three.WebApi.Services;

namespace Two.MVC.Controllers
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
            try
            {
                //throw new Exception("tes err");
                TempData["error"] = null;
                var blogs = _blogService.GetAll();
                if (blogs!.Count <= 0) TempData["error"] = "Blogs Not found";
                return View("Index",blogs);
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
                return View("Index");
            }
        }

        [HttpGet("/blogs/detail/{id}")]
        public IActionResult Detail([FromRoute]int id) 
        {
            try
            {
                //throw new Exception("tes err");
                TempData["error"] = null;
                if (id <=0 )TempData["error"] = "id is not invalid";
                var blog = _blogService.GetOne(id);
                if (blog is null) TempData["error"] = "Blog not found!";
                return View("Detail",blog);
            }
            catch (Exception err)
            {
                TempData["error"] = err.Message;
                return View("Detail");
            }
        }

        [HttpGet]   
        public IActionResult CreateView()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateAction([FromForm]TblBlog blog)
        {
            try
            {
                //throw new Exception("tes err");
                TempData["error"] = null;
                var newBlog = _blogService.Create(blog);
                if (newBlog is null) TempData["error"] = "create fail ";
                return RedirectToAction("Index");
            }
            catch (Exception err)
            {
                TempData["error"] = err.Message;
                return RedirectToAction("Index");
            }
        }

        [HttpGet("/blogs/edit/{id:int}")]
        public IActionResult Edit([FromRoute]int id)
        {
            var oldBLog = _blogService.GetOne(id);
            return View("Edit",oldBLog);
        }

        [HttpPost("/blogs/update/{id:int}")]
        public IActionResult Update([FromRoute]int id,[FromForm]TblBlog blog)
        {
            try
            {
                TempData["error"] = null;
                var updateBlog = _blogService.Update(id, blog);
                if(updateBlog is null) TempData["error"] = "Update fail";
                return RedirectToAction("Index");
            }
            catch (Exception err)
            {
                TempData["error"] = err.Message;
                return RedirectToAction("Index");
            }

        }


        public IActionResult Delete(int id)
        {
            TempData["error"] = null;
            var isSuccess = _blogService.Delete(id);
            if (!isSuccess) TempData["error"] = "delete fail";
            return RedirectToAction("Index");
        }

    }
}
