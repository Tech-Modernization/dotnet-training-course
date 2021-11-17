using System;
using System.Collections.Generic;
using System.Linq;

namespace Kata.CustomTypes.Kata.Recipe.Part9
{
    public class SpagBol : DishBase
    {
        public SpagBol() : base("Spaghetti Bolognese")
        {
            Add(Pantry.Measure("spaghetti", "125g"));
            Add(Pantry.Measure("beef mince", "1/2 lb"));
            Add(Pantry.Measure(() => new Tomato("half a dozen", () => PrepTomatoes())));
        }

        private void PrepTomatoes()
        {
            Console.WriteLine("soak in boiled water, skin and mash");
        }
    }
}
