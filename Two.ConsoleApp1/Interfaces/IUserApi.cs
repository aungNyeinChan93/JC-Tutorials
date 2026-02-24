using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using Two.ConsoleApp1.Models;

namespace Two.ConsoleApp1.Interfaces
{
    public interface IUserApi
    {
        [Get("/users")]
        Task<Users> GetUsersAsync();

        [Get("/users/{id}")]
        Task<User> GetUserAsync(int id);


        [Post("/users/add")]
        Task<User> CreateUserAsync(User user);

        [Put("/users/{id}")]
        Task<User> UpdateUserAsync(int id, User user);

        [Delete("/users/{id}")]
        Task<User> DeleteUserAsync(int id);
    }
}
