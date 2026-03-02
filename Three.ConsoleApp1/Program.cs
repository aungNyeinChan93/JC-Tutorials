using Database_02.Models;
using five.WebApi.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Abstractions;
using Serilog;




//new ServiceCollection().AddDbContext<AppDbContext>(())

//var service = new ServiceCollection().AddSingleton<BlogService>().BuildServiceProvider();
//var blogService = service.GetRequiredService<BlogService>();


//var blogs = blogService.GetAllBlogs();

//foreach (var blog in blogs!)
//{
//    Console.WriteLine($"Blog Title ==> {blog.Title}");
//}

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .WriteTo.Console()
    .WriteTo.File("log/test_Log.txt",
        rollingInterval: RollingInterval.Day,
        rollOnFileSizeLimit: true)
    .CreateLogger();


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

Log.Information("Testing log ");


