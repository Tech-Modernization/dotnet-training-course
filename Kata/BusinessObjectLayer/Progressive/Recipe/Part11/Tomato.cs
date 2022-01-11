using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessObjectLayer.Recipe.Part11
{
    public class Tomato : Ingredient
    {
        public Tomato(string amount) : base("tomato", amount)
        {
        }
        public Tomato(string amount, Action altPrep) : base("tomato", amount, altPrep)
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