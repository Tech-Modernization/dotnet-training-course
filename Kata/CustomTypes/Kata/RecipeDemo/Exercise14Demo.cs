using System;
using System.Collections.Generic;
using System.Text;

namespace Kata.CustomTypes.RecipeDemo
{
    public class Exercise14Demo
    {
        public void Run()
        {
            var ingredients = new List<Ingredient>();
            Func<string, string, Ingredient> measure = (name, amount) => new Ingredient(name, amount);
            ingredients.Add(measure("egg", "4"));
            ingredients.Add(measure("salt", " a pinch"));
            ingredients.Add(measure("beef mince", "1/2 lb"));
            ingredients.Add(measure("spaghetti", "250g"));
            ingredients.Add(new Tomato("half a dozen"));

            foreach (var i in ingredients)
            {
                Console.WriteLine(i);
                i.Prepare();
            }

            var stage = new Stage("roux");
            Console.WriteLine(stage);

            /*
            var recipe = new Recipe<string>("basic sauce");

            var rouxStage = recipe.Process(anonIngreds =>
            {
                var s = new Stage("making the roux");
                foreach (var i in anonIngreds)
                {
                    i.Prepare();
                    Console.WriteLine("Adding to the roux");
                }
                s.Ready = true;
                return s;
            },
                               new Ingredient("flour", "200g"),
                               new Ingredient("butter", "half a block"),
                               new Ingredient("milk", "some"));

            */

            //var listSalad = new List<Salad>();

            var spagBol = new Recipe<SpagBol>();
            Console.WriteLine(spagBol);
          
            var salad = new Recipe<Salad>();
            Console.WriteLine(salad);

        }
    }
}
