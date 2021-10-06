using Kata.CustomTypes.MenuFactory;
using System;
using System.Collections.Generic;

namespace Kata
{
    class Program
    {
        static void Main(string[] args)
        {
            var dm = new DrinksMenu();
            foreach(var dmi in dm.Items)
            {
                Console.WriteLine($"{dmi.Name} will cost you {dmi.Price:C}");
            }


            var dict = new Dictionary<int, string>();
            dict.Add(1, "me");
            dict.Add(2, "you");
            dict.Add(24, "uncle pete");
            dict.Add(4000000, "aunty beryl");

            Console.WriteLine($"{dict[2]}");

            foreach(var k in dict.Keys)
            {
                Console.WriteLine(dict[k]);
            }

            dict.Clear();
            do
            {
                Console.Write("Gimme a key:");
                var key = Console.ReadLine();
                if (key.Length == 0) break;
                Console.Write("Gimme a name:");
                var name = Console.ReadLine();
                if (name.Length == 0) break;

                if (dict.ContainsKey(int.Parse(key)))
                {
                    dict[int.Parse(key)] = name;
                    continue;
                }

                dict.Add(int.Parse(key), name);

            } while (true);

            foreach (var k in dict.Keys)
            {
                Console.WriteLine(dict[k]);
            }
        }
    }
}
