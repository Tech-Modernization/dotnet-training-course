using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Kata.CustomTypes.Extensions;
using Kata.DataServices;

namespace Kata.CustomTypes.RecipeDemo
{
    public class Pantry : IPantry
    {
        protected IFileDataService DataService;
        protected Dictionary<string, string> stock;
        public Pantry(IFileDataService dataService)
        {
            DataService = dataService;
            //stock = DataService.LoadDictionary<Dictionary<string, string>>("ingredients.json");
        }
        public Ingredient Measure(string name, string amount)
        {
            return new Ingredient(name, amount);
        }

        public TIngredient Measure<TIngredient>(Func<TIngredient> instantiate)
        {
            return instantiate();
        }

        public Ingredient Measure(string strIngredient)
        {
            var collapsed = strIngredient.ToLower().Replace(" ", "");
            var matches = stock.Keys.Where(k => k.ToLower()
                                   .Replace(" ", "")
                                   .StartsWith(collapsed))
                                   .ToList();

            if (matches.Count == 1)
            {
                return Measure(matches[0], stock[matches[0]]);
            }

            if (matches.Count == 0)
            {
                return Measure(strIngredient, "do not have any of these");
            }

            // if more than one match - this is dodgy, maybe better to throw exception
            return null;
        }
    }
}
