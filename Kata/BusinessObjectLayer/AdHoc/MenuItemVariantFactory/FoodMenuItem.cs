using System;
using System.Collections.Generic;
using System.Text;

namespace Kata.CustomTypes.MenuItemVariantFactory
{
    public class FoodMenuItem : MenuItemBase
    {
        protected override void CreateVariants()
        {
            Variants.Add(new FoodMenuItemVariant("Fish & Chips", 5.5M));
            Variants.Add(new FoodMenuItemVariant("Cooked Breakfast", 7.25M));
            Variants.Add(new FoodMenuItemVariant("Sausage, Mash & Gravy", 4.5M));
        }
    }
}
