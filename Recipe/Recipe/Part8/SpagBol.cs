using System;
using System.Collections.Generic;
using System.Linq;

namespace Recipe.Part8
{
    public class SpagBol : DishBase
    {
        public SpagBol() : base("Spaghetti Bolognese")
        {
            Add(Pantry.Measure("spaghetti", "125g"));
            Add(Pantry.Measure("beef mince", "1/2 lb"));
            Add(Pantry.Measure(() => new Tomato("half a dozen", () => Console.WriteLine("soak in boiled water, skin and mash"))));
        }
    }
}
