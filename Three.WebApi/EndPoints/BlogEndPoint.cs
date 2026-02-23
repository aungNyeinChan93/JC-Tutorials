using Database_02.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Three.WebApi.Services;

namespace Three.WebApi.EndPoints
{
    public static class BlogEndPoint // presentation layer
    {
        public static WebApplication UseBlogs(this WebApplication app)
        {
            var group = app.MapGroup("/api/blogs"); 

            group.MapGet("/", ([FromServices] IBlogService blogService ) => // Action|method dependency injection
            {
                var blogs = blogService.GetAll();
                return Results.Ok(blogs);
            });

            group.MapGet("/{id:int}", ([FromServices] IBlogService blogService, [FromRoute]int id) =>
            {
                var blog = blogService.GetOne(id);
                return Results.Ok(blog);
            }).WithName("Get-blog");

            group.MapPost("/", ([FromServices]IBlogService blogService, [FromBody]TblBlog blog) =>
            {
                var result = blogService.Create(blog);
                return result is not null ? Results.CreatedAtRoute("Get-blog",new {id = result.BlogId },result) : Results.BadRequest();
            });

            group.MapPut("/{id:int}", ([FromServices]IBlogService blogService, [FromRoute]int id, [FromBody]TblBlog blog) =>
            {
                var result = blogService.Update(id, blog);
                return result is not null ? Results.Ok(result): Results.BadRequest();

            });

            group.MapDelete("/{id:int}", ([FromServices]AppDbContext db, [FromRoute]int id) =>
            {
                //var result = blogService.Delete(id);
                var blog = db.TblBlogs.AsNoTracking().FirstOrDefault(b => b.BlogId == id);
                if(blog is null) return Results.BadRequest();
                db.Entry(blog).State = EntityState.Deleted;
                var result =db.SaveChanges();
                return result >=1 ? Results.NoContent() : Results.BadRequest();
            });

            return app;
        }
    }
}
