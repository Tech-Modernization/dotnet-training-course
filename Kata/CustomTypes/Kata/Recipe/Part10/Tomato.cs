using System;
using System.Collections.Generic;
using System.Text;

namespace Kata.CustomTypes.Demo.Recipe.Part10
{
    public class Tomato : Ingredient
    {
        public Tomato(string amount) : base("tomato", amount)
        {
        }
        public Tomato(string amount, Action altPrepMethod) : this(amount)
        {
            AltPrepMethod = altPrepMethod;
        }


        public override void Prepare()
        {
            base.Prepare();
            Console.WriteLine("Slicing the tomatos");
        }
    }
}