using One.ConsoleApp1.Interfaces;
using One.ConsoleApp1.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Text;

namespace One.ConsoleApp1.EndPoint
{
    public class RecipesEndPoint
    {

        private readonly string _url = "https://dummyjson.com";

        private IRecipeApi _recipeApi;

        public RecipesEndPoint()
        {
            this._recipeApi = RestService.For<IRecipeApi>(this._url);
        }

        public async Task<Recipes?> GetAllAsync()
        {
            //var recipeApi = RestService.For<IRecipeApi>(this._url);
            var result = await _recipeApi.GetRecipesAsync();
            return result;
        }

        public async Task<Recipe?> GetByIdAsync(int id)
        {
            //var recipeApi = RestService.For<IRecipeApi>(this._url);
            var result =await _recipeApi.GetOneAsync(id);
            return result;
        }

        public async Task<Recipe?> CreateAsync(Recipe recipe)
        {
            var result =await _recipeApi.CreateAsync(recipe);
            return result;
        } 

        public async Task<Recipe?> UpdateAsync(int id,Recipe recipe)
        {
            var result = await _recipeApi.UpdateAsync(recipe, id);
            return result;
        }

        public async Task<Recipe?> DeleteAsync(int id)
        {
            var result =await _recipeApi.DeleteAsync(id);
            return result;
        }
    }
}
