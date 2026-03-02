using Database_02.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace One.RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuotesController : ControllerBase
    {
        private readonly ILogger<QuotesController> _logger;

        public QuotesController(ILogger<QuotesController> logger)
        {
            _logger = logger;
        }

        //[Route("/api/quotes/one")]
        [HttpGet("one")]
        public IActionResult TestOne()
        {
            return Ok("test one");
        }

        [HttpGet("two")]
        public async Task<IActionResult> TestTwo([FromServices]AppDbContext db)
        {
            _logger.LogInformation("Test api start");
            var blogs = await db.TblBlogs.AsNoTracking().ToListAsync();
            _logger.LogInformation($"Blogs => {JsonConvert.SerializeObject(blogs,Formatting.Indented)}");

            _logger.LogInformation("Test api end");

            return Ok(blogs);
        }
    }
}
