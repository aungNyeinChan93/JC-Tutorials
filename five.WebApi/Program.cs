using Database_02.Models;
using five.WebApi.EndPoints;
using five.WebApi.Interfaces;
using five.WebApi.Models;
using five.WebApi.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Refit;
using RestSharp;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();


builder.Services.AddDbContext<AppDbContext>((config) =>
{
    config.UseSqlServer(builder.Configuration.GetConnectionString("DbConnection"));
});

builder.Services.AddScoped<IBlogService,BlogService>();

builder.Services.AddSingleton( x =>new HttpClient() { BaseAddress = new Uri(builder.Configuration.GetSection("api").Value!) });

builder.Services.AddScoped( r => new RestClient(builder.Configuration.GetSection("api").Value!));

builder.Services.AddScoped(x => RestService.For<IProductService>(builder.Configuration.GetSection("api").Value!));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseBlogs();

app.MapGet("/api/todos", async ([FromServices] HttpClient httpClient) =>
{
    var response = await httpClient.GetAsync("/todos");
    if(!response.IsSuccessStatusCode) return Results.BadRequest();

    var res = await response.Content.ReadAsStringAsync();
    var result = JsonConvert.DeserializeObject<Todos>(res);
    return Results.Ok(result!.todos);
});

app.MapGet("/api/quotes", async ([FromServices]RestClient restClient) =>
{
    var req = new RestRequest("/quotes", Method.Get);
    var result = await restClient.GetAsync<Quotes>(req);
    return Results.Ok(result);
});

app.MapGet("/api/products", async ([FromServices] IProductService restService) =>
{
    var products = await restService.GetAllProductsAsync();
    return Results.Ok(products);
});

app.Run();
