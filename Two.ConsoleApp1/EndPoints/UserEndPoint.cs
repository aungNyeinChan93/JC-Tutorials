using System;
using System.Collections.Generic;
using System.Text;
using Two.ConsoleApp1.Models;
using Two.ConsoleApp1.Services;

namespace Two.ConsoleApp1.EndPoints
{
    public class UserEndPoint
    {
        private readonly UserService _service ;

        public UserEndPoint()
        {
            this._service = new UserService();
        }

        public async Task<Users?> GetUsersAsync()
        {
            var users = await _service.GetUsersAsync();
            return users;
        }

        public async Task<User?> GetUserAsync(int id)
        {
            var user = await _service.GetUserAsync(id);
            return user;
        }

        public async Task<User?> CreateUserAsync(User user)
        {
            var u = await _service.CreateUserAsync(user);
            return u;
        }

        public async Task<User?> UpdateUserAsync(int id,User user)
        {
            var u = await _service.UpdateUserAsync(id,user);
            return u;
        }

        public async Task<User?> DeleteUserAsync(int id)
        {
            var u = await _service.DeleteUserAsync(id);
            return u;
        }
    }
}
