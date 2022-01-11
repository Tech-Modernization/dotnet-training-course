using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessObjectLayer.Recipe.Part15
{
    public class Ingredient : IPreparer
    {
        public string Name { get; }
        public string Amount { get; }

        protected Action AltPrepMethod;

        public Ingredient(string name, string amount)
        {
            Name = name;
            Amount = amount;
        }
        public Ingredient(string name, string amount, Action altPrep) : this(name, amount)
        {
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
