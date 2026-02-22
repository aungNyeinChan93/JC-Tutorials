using Database_01.Models;
using Microsoft.AspNetCore.Mvc;
using Two.WebApi.Dtos.Games;
using Two.WebApi.Helpers;
using Two.WebApi.Models;
using Two.WebApi.Services;

namespace Two.WebApi.EndPoints
{
    public static class GameEndPoint
    {
        public static GameService _gameService = new GameService();
        public static WebApplication UseGames(this WebApplication app)
        {
            var group = app.MapGroup("/api/games");

            group.MapGet("/", () =>
            {
                try
                {
                    var result = _gameService.GetAllGames();

                    if (result.IsError)
                    {
                        if (result.ResponseType == ResponseType.SystemError) return Results.StatusCode(500);
                        if (result.ResponseType == ResponseType.ValidationError) return Results.BadRequest("Client Error");
                    }
                    return Results.Ok(new { Games = result.ResponseData });
                    //ResponseHelper.Execute<List<Game>?>(result);
                }
                catch (Exception err)
                {
                    return Results.BadRequest(err.Message);
                }
            });

            group.MapGet("/{id}", ([FromRoute]int id) =>
            {
                try
                {
                    var result = _gameService.GetGame(id);
                    if (result.IsError)
                    {
                        if (result.ResponseType == ResponseType.ValidationError) return Results.NotFound("Game Not found!");
                        if (result.ResponseType == ResponseType.SystemError) return Results.StatusCode(500);
                    }
                    return Results.Ok(result.ResponseData);
                }
                catch (Exception err)
                {
                    return Results.BadRequest(new {Message =  err.Message});
                }
            }).WithName("GETGAME");

            group.MapPost("/", ([FromBody] CreateGameDto createGameDto) =>
            {
                var game = _gameService.Create(createGameDto);
                if (game is null) return Results.BadRequest();
                return Results.CreatedAtRoute("GETGAME",new {id = game.GameId} ,game);
            });

            return app;
        }
    }
}
