using One.ConsoleApp1.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Text;

namespace One.ConsoleApp1.Interfaces
{
    public interface IRecipeApi
    {
        [Get("/recipes")]
        Task<Recipes> GetRecipesAsync();


        [Get("/recipes/{id}")]
        Task<Recipe> GetOneAsync(int id);

        [Post("/recipes/add")]
        Task<Recipe> CreateAsync([Body] Recipe recipe);

        [Put("/recipes/{id}")]
        Task<Recipe> UpdateAsync([Body] Recipe recipe, int id);

        [Delete("/recipes/{id}")]
        Task<Recipe> DeleteAsync(int id);
    }
}
