using System;
using System.Collections.Generic;
using System.Text;

namespace Kata.Demos
{
    public class Exercise12Demo : DemoBase
    {
        public void Run()
        {
            var multi = new Multiplier();
            multi.Multiply(22, 5);
            multi.Multiply(2.3M, 5);
            multi.Multiply("Paul woz 'ere", 11);
            multi.Multiply(new Hammer("Claw"), 3);
            multi.Multiply(new Shoes("Docs", 10), 4);
            
        }

        public class Multiplier
        {
            public void Multiply<T>(T arg, int multiplier)
            {
                var isInt = arg is int;
                var isDecimal = arg is decimal;
                var isString = arg is string;

                if (isInt)
                {
                    var convertedInt = Convert.ToInt32(arg);
                    multiplyNumber(convertedInt, multiplier);
                    return;
                }
                if (isDecimal)
                {
                    var convertedDecimal = Convert.ToDecimal(arg);
                    multiplyNumber(convertedDecimal, multiplier);
                    return;
                }
                if (isString)
                {
                    var strArg = arg as string;
                    multiplyString(strArg, multiplier);
                    return;
                }

                var asHammer = arg as Hammer;
                if (asHammer != null)
                {
                    multiplyHammer(asHammer, multiplier);
                    return;
                }

                Console.WriteLine($"{typeof(T).Name} is not a supported type");
                Console.WriteLine($"{arg.GetType().Name} is not a supported type");

            }

            private void multiplyHammer(Hammer asHammer, int multiplier)
            {
                var list = new List<Hammer>();
                for (var i = 1; i <= multiplier; i++)
                {
                    list.Add(new Hammer($"{asHammer.FormatDetails()} #{i}"));
                }

                Console.WriteLine(string.Join("\n", list));
            }

            private void multiplyString(string strArg, int multiplier)
            {
                for (var i = 1; i <= multiplier; i++)
                {
                    Console.WriteLine($"Repeat #{i}: {strArg}");
                }
            }

            private void multiplyNumber(int v, int multiplier)
            {
                Console.WriteLine($"{v} x {multiplier} = {v * multiplier}");
            }
            private void multiplyNumber(decimal v, int multiplier)
            {
                Console.WriteLine($"{v} x {multiplier} = {v * multiplier}");
            }
        }
    }
}
