using System;
using System.Collections.Generic;
using System.Text;

namespace PresentationLayer
{
    public class IntroToGenerics_Multiplier : DemoBase
    {
        public override void Run()
        {
            var multiplier = new Multiplier();
            multiplier.Multiply(22, 4);
            multiplier.Multiply(2.2M, 5);
            multiplier.Multiply("22", 7);
            multiplier.Multiply(new Hammer("Claw"), 5);
            multiplier.Multiply(new Shoes("Docs", 10), 8);
        }

        public class Hammer
        {
            string name;

            public Hammer(string name)
            {
                this.name = name;
            }
            public string FormatDetails()
            {
                return $"{name}";
            }
        }

        public class Shoes
        {
            int size;
            string style;

            public Shoes(string style, int size)
            {
                this.size = size;
            }

        }
        public class Multiplier
        {
            public void Multiply<T>(T arg, int multiplier)
            {
                if (arg is int)
                {
                    multiplyNumber(Convert.ToInt32(arg), multiplier);
                    return;
                }
                if (arg is decimal)
                {
                    multiplyNumber(Convert.ToDecimal(arg), multiplier);
                    return;
                }

                var str = arg as string;
                if (!string.IsNullOrEmpty(str))
                {
                    multiplyString(str, multiplier);
                    return;
                }
                var hammer = arg as Hammer;
                if (hammer != null)
                {
                    multiplyHammer(hammer, multiplier);
                    return;
                }

                Console.WriteLine($"Sorry.  Multiplier does not support the {typeof(T).FullName} type");
            }


            private void multiplyHammer(Hammer hammer, int multiplier)
            {
                var list = new List<Hammer>();
                var hammerStr = hammer.FormatDetails();
                for (var i = 0; i < multiplier; i++)
                {
                    list.Add(new Hammer($"{hammerStr} #{i + 1} of {multiplier}"));
                }

                foreach (var h in list)
                    Console.WriteLine(h.FormatDetails());
            }

            private void multiplyString(string str, int multiplier)
            {
                for (var i = 1; i < multiplier; i++)
                {
                    Console.WriteLine($"{i}: {str}");
                }
            }

            private void multiplyNumber(int arg, int multiplier)
            {
                Console.WriteLine($"{multiplier} x {arg} = {multiplier * arg}");
            }
            private void multiplyNumber(decimal arg, int multiplier)
            {
                Console.WriteLine($"{multiplier} x {arg} = {multiplier * arg}");
            }
        }

    }
}
