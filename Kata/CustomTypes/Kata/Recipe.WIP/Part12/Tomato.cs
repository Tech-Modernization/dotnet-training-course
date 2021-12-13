using System;

namespace Kata.CustomTypes.WIP.Recipe.Part12
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