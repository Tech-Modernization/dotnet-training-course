using System;
using System.Collections.Generic;
using System.Text;
using Kata.CustomTypes.AccommodationFactory;

namespace Kata.Demos
{
    public class AccomondationFactoryDemo  
    {
        public void Run()
        {
            var creators = new EnclosureBase[2];
            creators[0] = new Field();
            creators[1] = new CaravanPark();
            foreach (var creator in creators)
            {
                Console.WriteLine(creator);
                foreach (var product in creator.Units)
                {
                    Console.WriteLine($"   {product}");
                }
            }
        }
    }
}
