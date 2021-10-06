using System;
using System.Collections.Generic;
using System.Globalization;

namespace DemoKata.CustomTypes
{
    public class DrinksMenu
    {
        private List<Drink> Menu = new List<Drink>();
        
        public void Update(Drink drink)
        {
            Menu.Add(drink);
        }

        public void Display()
        {
            CultureInfo ci = new CultureInfo("en-GB");

            Console.WriteLine("");
            Console.WriteLine("");
            for (var opt = 0; opt < Menu.Count; opt++)
            {
                Console.WriteLine($"{(opt + 1), 3}. {(Menu[opt].Name), -12} {Menu[opt].Price.ToString("C", ci)} ");
            }
            Console.WriteLine($"\n{(Menu.Count+1), 3}. Finished Ordering");
            Console.WriteLine("");
        }

        public Drink MenuItem(int item)
        {
            return Menu[item];
        }

        public int Count()
        {
            return Menu.Count;
        }

        public decimal Price(int Item)
        {
            return Menu[Item].Price;
        }

        public bool GetSelection(Order order)
        {
            var index = 0;
            var selOk = false;

            var rangeVal = new RangeValidator(1, Menu.Count + 1);
            while (!selOk)
            {
                Console.Write("Enter your selection: ");
                var intOk = int.TryParse(Console.ReadLine(), out index);

                selOk = intOk && rangeVal.IsValid(index);

                if (selOk)
                    {
                    if (index <= Menu.Count)
                        order.Add(Menu[index - 1]);
                    else
                        return false;
                    }
                else
                    Console.WriteLine("Bad selection!");

            }
            Console.Clear();

            return true;
        }


    }
}
