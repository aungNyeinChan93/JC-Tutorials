using Database_01.Models;
using Microsoft.EntityFrameworkCore;
using Two.WebApi.Dtos.Games;
using Two.WebApi.Models;

namespace Two.WebApi.Services
{
    public class GameService
    {
        private readonly AppDbContext _db = new AppDbContext();

        public  BaseResponseModel<List<Game>> GetAllGames()
        {
            var games = _db.Games.AsNoTracking().ToList() as List<Game>;
            var response = BaseResponseModel<List<Game>>.Success(true, 200, "Get all games",games);
            return response;
        }

        public Game? GetGame(int id)
        {
            var game = _db.Games.FirstOrDefault(g=>g.GameId == id);
            return game;
        }

        public Game? Create(CreateGameDto createGameDto)
        {
            var newGame = new Game { Name = createGameDto.Name, Genre = createGameDto.Genre, Price = createGameDto.Price, ReleaseDate = createGameDto?.ReleaseDate };
            _db.Add(newGame);
            var res = _db.SaveChanges();
            return res >=1 ? newGame :null;
        }
    }
}
