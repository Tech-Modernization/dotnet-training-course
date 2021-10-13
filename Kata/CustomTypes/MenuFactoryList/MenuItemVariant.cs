using System;
using System.Collections.Generic;
using System.Text;

namespace Kata.CustomTypes.MenuFactoryList
{
    public class MenuItemVariant
    {
        public string Name { get; set; }
        public decimal Price { get; set; }

        protected const int NameWidth = -30;
        protected const int PriceWidth = 10;

        public MenuItemVariant(string name, decimal price)
        {
            Name = name;
            Price = price;
        }

        public override string ToString()
        {
            var tempPrice = $"{Price:C}";
            return $"{Name,NameWidth}{tempPrice,PriceWidth}";
        }
    }
}
