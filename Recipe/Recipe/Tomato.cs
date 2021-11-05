using System;
using System.Collections.Generic;
using System.Text;

namespace Recipe
{
    public class Tomato : Ingredient
    {
        public Tomato(string amount) : base("tomato", amount)
        {
        }

        public override void Prepare()
        {
            Console.WriteLine("Slicing the tomato(s)");
        }
    }
}
