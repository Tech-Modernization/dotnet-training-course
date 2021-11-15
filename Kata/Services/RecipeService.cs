using System;
using System.Collections.Generic;
using System.Text;

using Kata.CustomTypes.RecipeDemo;
namespace Kata.Services
{
    public class RecipeService : IRecipeService
    {
        public List<Recipe<DishBase>> GetRecipes()
        {
            return new List<Recipe<DishBase>>();
        }

    }
}
