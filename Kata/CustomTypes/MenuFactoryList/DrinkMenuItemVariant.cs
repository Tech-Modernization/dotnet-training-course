using System;
using System.Collections.Generic;
using System.Text;

namespace Kata.CustomTypes.MenuFactoryList
{
    public class DrinkMenuItemVariant : MenuItemVariant
    {
        public SizeVariant Size { get; }
        public DrinkMenuItemVariant(string name, decimal price) : base(name, price)
        {
        }
        public DrinkMenuItemVariant(string name, decimal price, SizeVariant size) : base(name, price)
        {
            Size = size;
        }

        public override string ToString()
        {
            var formattedPrice = $"{Price:C}";
            var formattedSize = $"({Size})";
            return $"    {Name,-40} {formattedSize,-15} {formattedPrice,10}";
        }
    }
}
