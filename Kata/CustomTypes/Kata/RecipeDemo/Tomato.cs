using System;
using System.Collections.Generic;
using System.Text;

namespace Kata.CustomTypes.RecipeDemo
{
    public class Tomato : Ingredient
    {
        public Tomato(string amount) : base("tomato", amount)
        {
        }
        public Tomato(string amount, Action altPrepMethod) : base("Tomato", amount, altPrepMethod)
        {
        }

        public override void Prepare()
        {
            Console.WriteLine("Slicing the tomato(s)");
        }
    }
}
