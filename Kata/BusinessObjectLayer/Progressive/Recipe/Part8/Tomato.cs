using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessObjectLayer.Recipe.Part8
{
    public class Tomato : Ingredient
    {
        public Tomato(string amount) : base("tomato", amount)
        {
        }

        public override void Prepare()
        {
            base.Prepare();
            Console.WriteLine("Slicing the tomatoes");
        }
    }
}