using System;
using System.Collections.Generic;
using System.Text;

namespace Kata.CustomTypes.RecipeDemo
{
    public class SpagBol : DishBase
    {
        public SpagBol() : base("Spaghetti Bolognese")
        {
            Add(Pantry.Measure("Spaghetti", "125g"));
            Add(Pantry.Measure("Olive oil", "1 tbsp"));
            Add(Pantry.Measure("Salt", "a pinch"));
            Add(Pantry.Measure("Beef mince", "1/2lb"));
            Add(Pantry.Measure<Tomato>(() => new Tomato("half a dozen")));
        }
    }
}
