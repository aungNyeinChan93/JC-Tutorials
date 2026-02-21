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
                var games = _gameService.GetAllGames();
                return Results.Ok(games);
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
