using System;
using System.Collections.Generic;
using System.Text;

namespace Kata.CustomTypes.MenuFactoryListDone
{
    public class CoffeeMenuItem : DrinkMenuItem
    {
        public CoffeeMenuItem() : base()
        {
            Name = "Coffee";
        }
        protected override void CreateVariants()
        {
            AddVariant("Americano", SizeVariant.Tall, 1.8M);
            AddVariant("Americano", SizeVariant.Grande, 2.5M);
            AddVariant("Americano", SizeVariant.Vente, 4.0M);
            AddVariant("Latte", SizeVariant.Tall, 2.2M);
            AddVariant("Latte", SizeVariant.Grande, 2.80M);
            AddVariant("Latte", SizeVariant.Vente, 4.4M);
            AddVariant("Cappuccino", SizeVariant.Tall, 2.8M);
            AddVariant("Cappuccino", SizeVariant.Tall, 4.0M);
            AddVariant("Americano", SizeVariant.Tall, 4.90M);
        }
    }
}
