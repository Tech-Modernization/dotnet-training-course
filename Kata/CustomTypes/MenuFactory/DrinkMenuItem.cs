using System;
using System.Collections.Generic;
using System.Text;

namespace Kata.CustomTypes.MenuFactory
{
    public class DrinkMenuItem : MenuItemBase
    {
        public Dictionary<SizeVariant, decimal> SizeVariants = new Dictionary<SizeVariant, decimal>();
    }
}
