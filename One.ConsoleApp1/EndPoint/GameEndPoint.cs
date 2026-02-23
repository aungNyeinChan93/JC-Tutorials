using Database_01.Models;
using One.ConsoleApp1.Interfaces;
using Refit;
using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Text;

namespace One.ConsoleApp1.EndPoint
{
    public class GameEndPoint
    {
        private readonly IGameApi _gameApi;

        private readonly string _url = "http://localhost:5013";

        public GameEndPoint()
        {
            _gameApi = RestService.For<IGameApi>(this._url);
        }

        public async Task<List<Game>?> GetGamesAsync()
        {
            var games = await _gameApi.GetGamesAsync();
            return games;
        }

        public async Task<Game?> GetGameAsync(int id)
        {
            var game = await _gameApi.GetGameAsync(id);
            return game;
        }

        public async Task<Game?> CreateGameAsync(Game game)
        {
            var newGame = await _gameApi.CreateGameAsync(game);
            return newGame;
        }
    }
}
