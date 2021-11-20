using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Newtonsoft.Json;

namespace Kata.CustomTypes.Kata.Recipe.Part10
{
    public class Pantry : IPantry
    {
        private Dictionary<string, string> stock;
        public Pantry()
        {
            stock = JsonConvert.DeserializeObject<Dictionary<string, string>>(File.ReadAllText("ingredients.json"));
        }
        private Ingredient Measure(string name, string amount)
        {
            return new Ingredient(name, amount);
        }

        public TIngredient Measure<TIngredient>(string searchName, Func<TIngredient> instantiate = null) where TIngredient : Ingredient
        {
            var collapsed = searchName.ToLower().Replace(" ", "");
            var matches = stock.Keys.Where(k => k.ToLower().Replace(" ", "").StartsWith(collapsed)).ToList();
            switch (matches.Count)
            {
                case 0:
                    throw new Exception($"No ingredients matching \"{searchName}\" were found");
                case 1:
                    if (instantiate == null)
                        return Measure(matches.First(), stock[matches.First()]) as TIngredient;
                    return instantiate();
                default:
                    throw new Exception($"Ambiguous ingredient \"{searchName}\" specified");
            }
        }
    }
}
