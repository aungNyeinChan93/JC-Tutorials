using Microsoft.AspNetCore.Mvc;
using Two.WebApi.Dtos.Games;
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
                var result = _gameService.GetAllGames();

                if (result.IsError)
                {
                    if (result.ResponseType == Models.ResponseType.SystemError) return Results.StatusCode(500);
                    if (result.ResponseType == Models.ResponseType.ValidationError) return Results.BadRequest("Client Error");
                }
                return Results.Ok(new {Games = result.ResponseData});
            });

            group.MapGet("/{id}", ([FromRoute]int id) =>
            {
                var games = _gameService.GetGame(id);
                return Results.Ok(games);
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
