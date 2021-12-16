using Kata.CustomTypes.Demo.Recipe.Part12;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kata.CustomTypes.Kata.Recipe.Part12Done
{
    public class Ingredient : IIngredient
    {
        public string Name { get; }
        public string Amount { get; }

        protected Action AltPrepMethod;

        public Ingredient(string name, string amount, Action altPrep = null)
        {
            Name = name;
            Amount = amount;
            AltPrepMethod = altPrep;
        }

        public override string ToString()
        {
            return $"Ingredient: {Name} ({Amount})";
        }
        public virtual void Prepare()
        {
            if (AltPrepMethod != null)
            {
                AltPrepMethod();
            }
            else
            {
                Console.WriteLine($"Preparing the {Name}");
            }
        }
    }
}
