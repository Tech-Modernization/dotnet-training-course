using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessObjectLayer.Progressive.OnlineShop.V2
{
    public class Product
    {
        public string Name { get; }
        public decimal Price { get; }
        public Product(string name, decimal price)
        {
            Name = name;
            Price = price;
        }
    }
}
