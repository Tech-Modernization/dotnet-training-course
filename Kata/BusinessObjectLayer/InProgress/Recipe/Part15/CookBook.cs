using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using Newtonsoft.Json.Linq;

namespace Kata.CustomTypes.Kata.Recipe.Part15
{
    public class CookBook : ICookBook
    {
        private List<string> pantrydb;
        private List<DishBase> dishesdb;

        private IRecipeService recipeService;

        public CookBook(IRecipeService _recipeService)
        {
            recipeService = _recipeService;
        }

        private Ingredient Measure(string name, string amount)
        {
            return new Ingredient(name, amount);
        }

        public Ingredient Measure(string strIngredient, string amount, Func<Ingredient> instantiator = null)
        {
            if (pantrydb == null)
            {
                pantrydb = recipeService.LoadPantry();
            }

            var ingredientQueryCollapsed = strIngredient.Replace(" ", "").ToLower();
            var matches = pantrydb.Where(key => key.Replace(" ", "").ToLower().StartsWith(ingredientQueryCollapsed)).ToList();

            switch(matches.Count)
            {
                case 0:
                    throw new Exception("Unrecognised ingredient specified");
                case 1:
                    var key = matches.First();
                    return instantiator == null ? Measure(key, amount) : instantiator();
                default:
                    throw new Exception("Ambiguous ingredient specified");
            }

            /*

            var manualMatches = new List<string>();    // var matches = 
            foreach(var key in stock.Keys)  // stock.Keys.Where
            {
                var removeSpaces = key.Replace(" ", "");  // key.Replace(" ", "")
                var lowercase = removeSpaces.ToLower();   // .ToLower()
                var collapsedMatchesFirstFewCharsOfKey = lowercase.StartsWith(ingredientQueryCollapsed); // .StartWith(...)
                if (collapsedMatchesFirstFewCharsOfKey) // LINQ does this internally
                {
                    manualMatches.Add(key);             // LINQ does this internally
                }
            }
            // .ToList()

            if (stock.ContainsKey(strIngredient))
            {
                return Measure(strIngredient, stock[strIngredient]);
            }
            */
        }

        public DishBase LoadDish(string dishName)
        {
            if (dishesdb == null)
            {
                dishesdb = recipeService.LoadDishes();
            }

            var safeDishName = dishName.Replace(" ", "").ToLower();
            var matches = dishesdb.Where(dish => dish.DishName.Replace(" ", "").ToLower().StartsWith(safeDishName)).ToList();

            switch (matches.Count)
            {
                case 0:
                    throw new Exception("Unrecognised dish specified");
                case 1:
                    var dish = matches.First();
                    return dish;
                default:
                    throw new Exception("Ambiguous dish specified");
            }

        }
    }
}
