using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using Two.ConsoleApp1.Interfaces;
using Two.ConsoleApp1.Models;

namespace Two.ConsoleApp1.Services
{
    public class UserService
    {
        private readonly string _url = "https://dummyjson.com";

        private IUserApi _userApi;

        public UserService()
        {
            _userApi = RestService.For<IUserApi>(this._url);
        }

        public async Task<Users?> GetUsersAsync()
        {
            var users = await _userApi.GetUsersAsync();
            return users;
        }

        public async Task<User?> GetUserAsync(int id)
        {
            var user = await _userApi.GetUserAsync(id);
            return user;
        }

        public async Task<User?> CreateUserAsync(User user)
        {
            var u = await _userApi.CreateUserAsync(user);
            return u;
        }

        public async Task<User?> UpdateUserAsync(int id, User user)
        {
            var u = await _userApi.UpdateUserAsync(id, user);
            return u;
        }

        public async Task<User?> DeleteUserAsync(int id)
        {
            var u = await _userApi.DeleteUserAsync(id);
            return u;
        }

    }
}
