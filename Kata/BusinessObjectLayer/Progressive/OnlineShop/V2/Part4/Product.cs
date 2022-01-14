using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessObjectLayer.Progressive.OnlineShop.V2.Part4
{
    // Encaps. Product details.
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
