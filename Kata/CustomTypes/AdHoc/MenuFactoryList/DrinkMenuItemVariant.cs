using System;
using System.Collections.Generic;
using System.Text;

namespace Kata.CustomTypes.MenuFactoryList
{
    public class DrinkMenuItemVariant : MenuItemVariant
    {
        public SizeVariant Size { get; set; }
        public DrinkMenuItemVariant(string name, decimal price, SizeVariant size) : base(name, price)
        {
            Size = size;
            switch(size)
            {
                case SizeVariant.Medium:
                    Price = price + 0.5M;
                    break;
                case SizeVariant.Large:
                    Price = price + 1.0M;
                    break;
                default:
                    Price = price;
                    break;
            }
        }

        public override string ToString()
        {
            var tempPrice = $"{Price:C}";
            var tempName = $"{Name} ({Size})";
            return $"{tempName,NameWidth}{tempPrice,PriceWidth}";
        }
    }
}
