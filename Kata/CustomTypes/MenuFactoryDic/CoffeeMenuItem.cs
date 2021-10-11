using System;
using System.Collections.Generic;
using System.Text;

namespace Kata.CustomTypes.MenuFactoryDic
{
    public class CoffeeMenuItem : DrinksMenuItem<CoffeeVariant>
    {
        public CoffeeMenuItem() : base()
        {
            Name = "Coffee";
        }
        protected override void CreateVariants()
        {
            Variants.AddVariant(CoffeeVariant.Americano, SizeVariant.Tall, 1.8M);
            Variants.AddVariant(CoffeeVariant.Americano, SizeVariant.Grande, 2.5M);
            Variants.AddVariant(CoffeeVariant.Americano, SizeVariant.Vente, 4.0M);
            Variants.AddVariant(CoffeeVariant.Latte, SizeVariant.Tall, 2.2M);
            Variants.AddVariant(CoffeeVariant.Latte, SizeVariant.Grande, 2.80M);
            Variants.AddVariant(CoffeeVariant.Latte, SizeVariant.Vente, 4.4M);
            Variants.AddVariant(CoffeeVariant.Cappuccino, SizeVariant.Tall, 2.8M);
            Variants.AddVariant(CoffeeVariant.Americano, SizeVariant.Tall, 4.0M);
            Variants.AddVariant(CoffeeVariant.Latte, SizeVariant.Tall, 4.90M);
        }
    }
}
