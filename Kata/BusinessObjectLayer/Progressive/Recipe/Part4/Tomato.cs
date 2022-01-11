using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessObjectLayer.Recipe.Part4
{
    public class Tomato : Ingredient
    {
        public Tomato(string amount) : base("tomato", amount)
        {
        }

        public override void Prepare()
        {
            Console.WriteLine($"Slicing the tomatoes");
        }
    }
}
