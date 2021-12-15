using System;
using System.Collections.Generic;
using System.Linq;

namespace Kata.CustomTypes.Kata.Recipe.Part12
{
    // 1. a predefined class needs to instantiate ingredients (and children of ingredients)
    // 2. a client of dishbase needs to have the means of doing the same, in a more transparent way.

    public class SpagBol : DishBase
    {
        public SpagBol() : base("Spaghetti Bolognese")
        {
            var instantiators = new Dictionary<string, Func<string, Ingredient>>();
            instantiators.Add("spag", (validName) => new Ingredient(validName, "125g"));
            instantiators.Add("beef", (validName) => new Ingredient(validName, "1/2lb"));
            instantiators.Add("peas", (validName) => new Peas("half a bag"));
            instantiators.Add("tomato", (validName) => new Tomato("half a dozen", () => Console.WriteLine("Chopping the tomatoes")));

            foreach(var instantiator in instantiators)
            {
                var matches = Pantry.LookupIngredient(instantiator.Key);
                if (matches.Count != 1)
                {
                    var result = matches.Count == 0 ? DishBuilderResult.IngredientNotFound : DishBuilderResult.AmbiguousIngredient;
                    throw new Exception($"{result}");
                }
                var ingred = instantiator.Value(matches.First());
                Ingreds.Add(ingred);
            }
        }
    }
}
