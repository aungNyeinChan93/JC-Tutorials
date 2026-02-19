using Microsoft.AspNetCore.Mvc;
using One.WebApi.Dtos.Games;

namespace One.WebApi.EndPoints
{
    public static class GameEndPoint
    {
        public static List<GameDto> games =
            [
                //new GameDto(2,"COC","Role Play",3.24M,new DateOnly(2012,12,12))
                new GameDto { Id = 1, Name = "COC", Genre = "Role Play", Price = 3000, ReleaseDate = new DateOnly(2012, 12, 2) },
                new GameDto {Id = 2 ,Name = "PUPG", Genre = "Shotting" , Price = 6000 ,ReleaseDate = new DateOnly(2018,11,2) }
            ];
        public static void UseGames(this WebApplication app )
        {

            var group = app.MapGroup("api/games");

            app.MapGroup("api/games").MapGet("/test",()=>" api/games/test");

            group.MapGet("/", () =>
            {
                if (games.Count <= 0) return Results.NotFound();
                return Results.Ok(new {Games  = games});
            });

            group.MapGet("/{id:int}", ([FromRoute]int? id) => Results.Ok(games.FirstOrDefault(g=>g.Id == id)) )
                .WithName("GETGAME");

            group.MapPost("/",([FromBody]CreateGameDto createGameDto) =>
            {
                var newGame = new GameDto
                {
                    Id = games.Max(g => g.Id)+1,
                    Name = createGameDto.Name,
                    Genre = createGameDto.Genre!,
                    Price = createGameDto.Price,
                    ReleaseDate = createGameDto.ReleaseDate
                };
                games.Add(newGame);
                return Results.CreatedAtRoute("GETGAME",new {id= newGame.Id},newGame);
            }).WithParameterValidation();


            group.MapPut("/{id:int}", ([FromRoute]int id,UpdateGameDto updateGameDto) =>
            {
                var index = games.FindIndex(g => g.Id == id);
                if(index == -1) return Results.NotFound();
                games[index] = new GameDto { Id = id, Name = updateGameDto.Name! ,Genre = updateGameDto.Genre! , Price = updateGameDto.Price! ,ReleaseDate = updateGameDto.ReleaseDate! };
                return Results.NoContent();
            });

            group.MapDelete("/{id:int}", ([FromRoute]int id) =>
            {
                //var isSuccess = games.RemoveAll(g=>g.Id == id);
                var removeGame = games.Find(x => x.Id == id);
                if (removeGame is null) return Results.NotFound();
                bool isSuccess = games.Remove(removeGame);
                return isSuccess ? Results.NoContent() : Results.BadRequest();
            });
        }
    }
}
