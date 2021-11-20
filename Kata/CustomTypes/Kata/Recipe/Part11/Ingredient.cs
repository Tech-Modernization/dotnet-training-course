using System;
using System.Collections.Generic;
using System.Text;

namespace Kata.CustomTypes.Demo.Recipe.Part11
{
    public class Ingredient : IIngredient
    {
        public string Name { get; }
        public string Amount { get; set; }
        
        public Action AltPrepMethod;
        public Ingredient(string name, string amount)
        {
            Name = name;
            Amount = amount;
        }
        public Ingredient(string name, string amount, Action altPrepMethod) : this(name, amount)
        {
            AltPrepMethod = altPrepMethod;
        }

        public virtual void Prepare()
        {
            Console.WriteLine($"Preparing the {Name}");
            if (AltPrepMethod != null)
            {
                AltPrepMethod();
            }
        }

        public override string ToString()
        {
            return $"Ingredient: {Name} ({Amount})";
        }
    }
}
