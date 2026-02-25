using Four.WebApi.EndPoints;
using Four.WebApi.Services;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();



app.MapGet("/", () => "Hello World!");

app.MapGet("/blogs", () =>
{
    BlogService.GetBlogs();


});



app.Run();
