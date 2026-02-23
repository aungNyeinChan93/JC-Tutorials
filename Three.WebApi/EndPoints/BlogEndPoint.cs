using Microsoft.AspNetCore.Mvc;
using Three.WebApi.Services;

namespace Three.WebApi.EndPoints
{
    public static class BlogEndPoint
    {
        public static WebApplication UseBlogs(this WebApplication app)
        {
            var group = app.MapGroup("/api/blogs");

            group.MapGet("/", ([FromServices] BlogService blogService ) => // Action|method dependency injection
            {
                var blogs = blogService.GetAll();
                return Results.Ok(blogs);
            });

            group.MapGet("/{id:int}", ([FromServices] BlogService blogService, [FromRoute]int id) =>
            {
                var blog = blogService.GetOne(id);
                return Results.Ok(blog);
            });

            return app;
        }
    }
}
