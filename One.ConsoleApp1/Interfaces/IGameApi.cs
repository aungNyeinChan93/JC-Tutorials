using Database_01.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Text;

namespace One.ConsoleApp1.Interfaces
{
    public interface IGameApi
    {
        [Get("/api/games")]
        Task<List<Game>> GetGamesAsync();

        [Get("/api/games/{id}")]
        Task<Game> GetGameAsync(int id);

        [Post("/api/games")]
        Task<Game?> CreateGameAsync([Body]Game game);
    }
}
