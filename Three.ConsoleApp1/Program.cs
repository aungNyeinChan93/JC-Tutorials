using Database_02.Models;
using five.WebApi.Services;
using Microsoft.Extensions.DependencyInjection;




//new ServiceCollection().AddDbContext<AppDbContext>(())

//var service = new ServiceCollection().AddSingleton<BlogService>().BuildServiceProvider();
//var blogService = service.GetRequiredService<BlogService>();


//var blogs = blogService.GetAllBlogs();

//foreach (var blog in blogs!)
//{
//    Console.WriteLine($"Blog Title ==> {blog.Title}");
//}



var services = new ServiceCollection();

// add services
services.AddDbContext<AppDbContext>();
services.AddSingleton<BlogService>();


var provider = services.BuildServiceProvider();

var blogService = provider.GetRequiredService<BlogService>();

var blogs = blogService.GetAllBlogs();

foreach (var blog in blogs!)
{
    Console.WriteLine($"Blog title ==>{blog.Title}");
}


