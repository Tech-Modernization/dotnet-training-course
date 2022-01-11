using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using Newtonsoft.Json.Linq;

namespace BusinessObjectLayer.Recipe.Part12
{
    public class Pantry : IPantry
    {
        private List<string> pantrydb;
        private IRecipeService recipeService;

        public Pantry(IRecipeService _recipeService)
        {
            recipeService = _recipeService;
            pantrydb = recipeService.LoadPantry();
        }

        public List<string> LookupIngredient(string name)
        {
            var safeName = name.Replace(" ", "").ToLower();
            var matches = pantrydb.Where(key => key.Replace(" ", "").ToLower().StartsWith(safeName)).ToList();
            return matches;
        }
    }
}
