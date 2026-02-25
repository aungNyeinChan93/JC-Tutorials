using five.WebApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace five.WebApi.EndPoints
{
    public static class BlogEndPoint
    {
        public static void UseBlogs(this WebApplication app)
        {
            var group = app.MapGroup("/api/blogs");

            group.MapGet("/",([FromServices]IBlogService blogService) =>
            {
                var blogs =  blogService.GetAllBlogs();
                return Results.Ok(blogs);
            });

           
        }
    }
}
