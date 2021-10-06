using System;
using System.Collections.Generic;
using System.Text;

namespace CustomTypes.DrinkFactory
{
    public class CoffeeDrinkVariant : Drink
    {
        protected override void CreateVariants()
        {
            Variant.Add(new Mocha());
            Variant.Add(new Latte());
        }
    }
}
