using System;
using System.Collections.Generic;
using System.Text;

namespace Kata.Demos
{
    public class Ingredient
    {
        protected string Name { get; }
        protected string Amount { get; }
        public Ingredient(string name, string amount)
        {
            Name = name;
            Amount = amount;
        }

        public override string ToString()
        {
            return $"Ingredient: {Amount} of {Name}";
        }
    }
}
