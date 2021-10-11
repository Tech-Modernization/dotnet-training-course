using System;
using System.Collections.Generic;
using System.Text;
using CustomTypes.HiFiFactory;

namespace Kata.Demos
{
    public class HiFiFactoryDemo
    {
        public static void Run()
        {
             var creators = new HomeStereoBase[2];
            creators[0] = new Separates();
            creators[1] = new MiniHifi();
            foreach (var creator in creators)
            {
                Console.WriteLine(creator);
                foreach (var product in creator.Components)
                {
                    Console.WriteLine($"   {product}");
                }
            }
        }
    }
}
