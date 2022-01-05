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
            DefineIngredient<Ingredient>("spag", "125g");
            DefineIngredient<Ingredient>("beef", "1/2/lb");
            DefineIngredient<Peas>("pea", "half a bag");
            DefineIngredient<Tomato>("tom", "half a dozen", new List<string> { "chop the tomatoes" });

            LoadIngredients();
       }
    }
}
