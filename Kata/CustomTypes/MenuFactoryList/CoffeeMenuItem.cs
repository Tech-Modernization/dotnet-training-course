using System;
using System.Collections.Generic;
using System.Text;

namespace Kata.CustomTypes.MenuFactoryList
{
    public class CoffeeMenuItem : DrinksMenuItem
    {
        public CoffeeMenuItem(string name, decimal price) : base(name, price)
        {
        }

        protected override void CreateVariants()
        {
            // it's either this or add a constructor argument to prevent the
            // creation of a default variant.  this is *much* simpler.
            Variants.Clear();

            for (var size = SizeVariant.Small; size <= SizeVariant.Large; size++)
            {
                Variants.Add(new DrinkMenuItemVariant("Americano", 1.8M, size));
                Variants.Add(new DrinkMenuItemVariant("Latte", 2.2M, size));
                Variants.Add(new DrinkMenuItemVariant("Cappuccino", 2.4M, size));
            }
            Variants.Sort((x, y) => x.Name.CompareTo(y.Name));
        }
    }
}
