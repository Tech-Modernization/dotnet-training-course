using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessObjectLayer.MenuFactoryListDone
{
    public class MenuItemVariant
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public MenuItemVariant(string name, decimal price)
        {
            Name = name;
            Price = price;
        }
        public override string ToString()
        {
            var formattedPrice = $"{Price:C}";
            return $"{Name,-40}{formattedPrice,10}";
        }
    }
}
