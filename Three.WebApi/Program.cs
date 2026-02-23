using Database_02.Models;
using Microsoft.EntityFrameworkCore;
using Three.WebApi.EndPoints;
using Three.WebApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddDbContext<AppDbContext>((option) =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("database_02"));
});

builder.Services.AddScoped<BlogService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();


app.UseBlogs();

app.Run();
