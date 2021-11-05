using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Kata.Demos
{
    public class Exercise14Demo : DemoBase
    {
        public override void Run()
        {
            var ingredients = new List<Ingredient>();
            Func<string, string, Ingredient> measure = (name, amount) => new Ingredient(name, amount);

            ingredients.Add(measure("egg", "4"));
            ingredients.Add(measure("salt", "a pinch"));
            ingredients.Add(measure("beef mince", "1/2 lb"));
            ingredients.Add(measure("spaghetti", "250g"));
        }
    }
}
