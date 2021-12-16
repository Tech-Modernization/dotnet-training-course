using System;
using System.Collections.Generic;
using System.Text;

namespace Kata.CustomTypes.Kata.Recipe.Part12Done
{
    public class Tomato : Ingredient
    {
        public Tomato(string name, string amount, Action altPrep = null) : base(name, amount, altPrep)
        {
        }

        public override void Prepare()
        {
            base.Prepare();

            if (AltPrepMethod == null)
            {
                Console.WriteLine("Slicing the tomatoes");
            }
        }
    }
}