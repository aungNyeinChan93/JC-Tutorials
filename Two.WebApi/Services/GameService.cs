using Database_01.Models;
using Microsoft.EntityFrameworkCore;
using Two.WebApi.Dtos.Games;
using Two.WebApi.Models;

namespace Two.WebApi.Services
{
    public class GameService
    {
        private readonly AppDbContext _db = new AppDbContext();

        public  BaseResponseModel<List<Game>?> GetAllGames()
        {
            var games = _db.Games.AsNoTracking().ToList() as List<Game>;

            if(games is null)
            {
                return BaseResponseModel<List<Game>?>.ValidationError(false,404,"Not found Games",games);
            }

            var response = BaseResponseModel<List<Game>?>.Success(true, 200, "Get all games",games);
            return response;
        }

        public BaseResponseModel<Game?> GetGame(int id)
        {
            var game = _db.Games.FirstOrDefault(g => g.GameId == id);
            if(game is null)
            {
                return BaseResponseModel<Game?>.SysTemError(false, 404, "Not found",game);
            }
            return BaseResponseModel<Game?>.Success(true, 200, "Get Game", game);
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
