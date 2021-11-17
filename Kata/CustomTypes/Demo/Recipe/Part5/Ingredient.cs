using System;
using System.Collections.Generic;
using System.Text;

namespace Recipe.Part5
{
    public class Ingredient : IIngredient
    {
        public string Name { get; }
        public string Amount { get; }
        public Ingredient(string name, string amount)
        {
            Name = name;
            Amount = amount;
        }

        public override string ToString()
        {
            return $"Ingredient: {Name} ({Amount})";
        }

        public virtual void Prepare()
        {
            Console.WriteLine($"Preparing the {Name}");
        }
    }

   
}
