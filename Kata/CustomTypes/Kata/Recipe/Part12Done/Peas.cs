using System;
using System.Collections.Generic;
using System.Text;

namespace Kata.CustomTypes.Kata.Recipe.Part12Done
{
    public class Peas : Ingredient
    {
        public Peas(string name, string amount, Action altPrep = null) : base(name, amount, altPrep)
        {
        }
    }
}
