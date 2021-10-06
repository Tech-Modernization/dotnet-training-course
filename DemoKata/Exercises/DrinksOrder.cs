using DemoKata.CustomTypes;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoKata.Exercises
{
    public class DrinksOrder : IExercise
    {
        public void Run()
        {
            var menu = new List<IDrink>();
            menu.Add(new Coffee());
            menu.Add(new Tea());
            menu.Add(new Wine());
            menu.Add(new Beer());

            var menuIndex = 1;
            foreach (var d in menu)
            {
                Console.WriteLine(d.GetMenuText(ref menuIndex));
            }
            Console.WriteLine($"{menuIndex++,3} Submit order\n\n");

            var done = false;
            var order = new Order();

            while (!done)
            {
                var index = 0;
                var selOk = false;
                var rangeVal = new RangeValidator(1, menu.Count + 1);
                while (!selOk)
                {
                    Console.Write("Enter your selection: ");
                    var intOk = int.TryParse(Console.ReadLine(), out index);

                    selOk = intOk && rangeVal.IsValid(index);
                    if (!selOk)
                        Console.WriteLine("Bad selection!");
                }

                if (index == 5) break;

                order.Add(menu[index - 1] as DrinkBase);
            }

            Console.WriteLine(order);

        }

        private string getSuffix(DrinkBase d)
        {
            if (d is Coffee)
            {
                var coffeeAs = d as Coffee;
                return $"({coffeeAs.Bean})";
            }

            return string.Empty;
        }
    }
}
