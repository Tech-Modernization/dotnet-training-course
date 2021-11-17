using System;
using System.Collections.Generic;
using System.Text;

namespace Kata.CustomTypes.RecipeDemo
{
    public class Mushroom : Ingredient
    {
        public Mushroom(string name, string amount, Action prepare) : base(name, amount, prepare)
        {
        }

        public override void Prepare()
        {
            Console.WriteLine("slicing mushrooms");
        }
    }
}
