using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessObjectLayer.Recipe.Part12
{
    public class Peas : Ingredient
    {
        public Peas(string name, string amount, Action altPrep = null) : base(name, amount, altPrep)
        {
        }
    }
}
