using Database_02.Models;
using Microsoft.AspNetCore.Mvc;
using Three.WebApi.Services;

namespace Three.WebApi.EndPoints
{
    public static class BlogEndPoint // presentation layer
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
            }).WithName("Get-blog");

            group.MapPost("/", ([FromServices]BlogService blogService, [FromBody]TblBlog blog) =>
            {
                var result = blogService.Create(blog);
                return result is not null ? Results.CreatedAtRoute("Get-blog",new {id = result.BlogId },result) : Results.BadRequest();
            });

            group.MapPut("/{id:int}", ([FromServices]BlogService blogService, [FromRoute]int id, [FromBody]TblBlog blog) =>
            {
                var result = blogService.Update(id, blog);
                return result is not null ? Results.Ok(result): Results.BadRequest();

            });

            group.MapDelete("/{id:int}", ([FromServices]BlogService blogService, [FromRoute]int id) =>
            {
                var result = blogService.Delete(id);
                return result ? Results.NoContent() : Results.BadRequest();
            });

            return app;
        }
    }
}
