using System;
using System.Collections.Generic;
using System.Text;

namespace Kata.CustomTypes.Kata.Recipe.Part7
{
    public class SpagBol : DishBase
    {
        public SpagBol() : base("Spaghetti Bolognese")
        {
            ingreds.Add(new Ingredient("spaghetti", "125g"));
            ingreds.Add(new Ingredient("lloyd grossman sauce", "1 jar"));
        }
    }
}
