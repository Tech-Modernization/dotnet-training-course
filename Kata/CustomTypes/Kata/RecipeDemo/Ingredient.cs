using System;
using System.Collections.Generic;
using System.Text;

namespace Kata.CustomTypes.RecipeDemo
{
    public class Ingredient : IIngredient
    {

        public string Name { get; }
        public string Amount { get; }
        public override string ToString()
        {
            return $"ingredient: {Amount} of {Name}";
        }

        public virtual void Prepare()
        {
            Console.WriteLine($"Preparing the {Name}");
        }

        public Ingredient(string name, string amount)
        {
            Name = name;
            Amount = amount;
        }

    }
}
