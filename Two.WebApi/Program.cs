using Two.WebApi.EndPoints;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.UseGames();

app.Run();
