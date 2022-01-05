using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using Newtonsoft.Json.Linq;

namespace Kata.CustomTypes.Kata.Recipe.Part10
{
    public class Pantry : IPantry
    {
        private List<string> pantrydb;

        public Pantry()
        {
            var jsonText = File.ReadAllText("cookbook.json");
            var jsonObject = JObject.Parse(jsonText);
            pantrydb = jsonObject.GetValue("ingredients").ToObject<List<string>>();
 
            // nothing wrong with this :-)
            //     var temp = JsonConvert.DeserializeObject<Dictionary<string, List<string>>>(jsonText);
            //     pantrydb = temp["ingredients"];
        }

        private Ingredient Measure(string name, string amount)
        {
            return new Ingredient(name, amount);
        }

        public Ingredient Measure(string strIngredient, string amount, Func<Ingredient> instantiator = null)
        {
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
    }
}
