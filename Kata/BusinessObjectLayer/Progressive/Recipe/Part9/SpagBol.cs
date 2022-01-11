using System;
using System.Collections.Generic;
using System.Linq;

namespace BusinessObjectLayer.Recipe.Part9
{
    public class SpagBol : DishBase
    {
        public SpagBol() : base("Spaghetti Bolognese")
        {
            Ingreds.Add(Pantry.Measure("spaghetti", "125g"));
            Ingreds.Add(Pantry.Measure(() => new Ingredient("lloyd grossman sauce", "1 jar", () => Console.WriteLine("open the jar"))));
            Ingreds.Add(Pantry.Measure(() => new Tomato("half a dozen", () => Console.WriteLine("Chopping the tomatoes"))));
        }
    }
}
