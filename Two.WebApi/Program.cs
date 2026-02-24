using Database_01.Models;
using Microsoft.EntityFrameworkCore;
using Two.WebApi.EndPoints;
using Two.WebApi.Services;

var builder = WebApplication.CreateBuilder(args);

/*  Services add  */
builder.Services.AddDbContext<AppDbContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("Game"));
},ServiceLifetime.Transient,ServiceLifetime.Transient);

builder.Services.AddScoped<GameService>();



var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.UseGames();

app.Run();
