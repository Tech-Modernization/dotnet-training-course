using System;
using System.Collections.Generic;
using System.Text;

namespace Kata.CustomTypes.RecipeDemo
{
    public class Ingredient : IIngredient
    {
        public string Name { get; set; }
        public string Amount { get; set; }
        public override string ToString()
        {
            return $"ingredient: {Amount} of {Name}";
        }

        public Action AltPrepMethod;

        public virtual void Prepare()
        {
            Console.WriteLine($"Preparing the {Name}");
            if (AltPrepMethod != null)
                AltPrepMethod();
        }

        public Ingredient(string name, string amount)
        {
            Name = name;
            Amount = amount;
        }
        public Ingredient(string name, string amount, Action prepare) : this(name, amount)
        {
            if (prepare != null)
            {
                AltPrepMethod = prepare;
            }
        }

    }
}
