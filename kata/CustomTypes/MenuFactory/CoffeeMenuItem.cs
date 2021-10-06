using System;
using System.Collections.Generic;
using System.Text;

namespace Kata.CustomTypes.MenuFactory
{
    public class CoffeeMenuItem : DrinkMenuItem
    {
        public Dictionary<CoffeeVariant, decimal> Variants = new Dictionary<CoffeeVariant, decimal>();

        public CoffeeMenuItem()
        {
            Variants.Add(CoffeeVariant.Mocha, 3M);
            Variants.Add(CoffeeVariant.Americano, 1M);
            Variants.Add(CoffeeVariant.Latte, 5M);
            Variants.Add(CoffeeVariant.Espressio, 2M);

            SizeVariants.Add(SizeVariant.Tall, 0M);
            SizeVariants.Add(SizeVariant.Grande, 0M);
            SizeVariants.Add(SizeVariant.Vente, 0M);
        }
    }
}
