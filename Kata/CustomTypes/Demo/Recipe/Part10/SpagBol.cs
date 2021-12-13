using System;
using System.Collections.Generic;
using System.Linq;

namespace Kata.CustomTypes.Demo.Recipe.Part10
{
    public class SpagBol : DishBase
    {
        public SpagBol() : base("Spaghetti Bolognese")
        {            
            Add(Pantry.Measure<Ingredient>("SP A G"));
            Add(Pantry.Measure<Ingredient>("b e e f m"));
            Add(Pantry.Measure("tom", () => new Tomato("half a dozen", () => PrepTomatoes())));
            Add(Pantry.Measure("MUSHro   om", () => new Ingredient("closed cup mushrooms", "one small punnet", PrepMushrooms)));
        }

        private void PrepMushrooms()
        {
            Console.WriteLine("de-stem and grate the mushrooms");
        }

        private void PrepTomatoes()
        {
            Console.WriteLine("soak in boiled water; drain, skin and mash them");
        }
    }
}
