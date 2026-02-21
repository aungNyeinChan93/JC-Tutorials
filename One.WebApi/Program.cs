using One.WebApi.DataBase;
using One.WebApi.EndPoints;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var connectionStr = builder.Configuration.GetConnectionString("GameStore");
builder.Services.AddSqlite<GameDbContext>(connectionStr);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();


app.UseGames();

app.Run();


