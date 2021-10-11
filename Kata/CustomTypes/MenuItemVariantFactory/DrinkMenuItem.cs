using System;
using System.Collections.Generic;
using System.Text;

namespace Kata.CustomTypes.MenuItemVariantFactory
{
    public class DrinkMenuItem : MenuItemBase
    {
        protected override void CreateVariants()
        {
            Variants.Add(new DrinkMenuItemVariant());
        }
    }
}
