using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessObjectLayer.Progressive.OnlineShop.V2.Part7
{
    // Encaps. Product details.
    public class Product
    {
        public string Name { get; }
        public decimal Price { get; }
        public bool IsNew { get; internal set; }
        public Product(string name, decimal price)
        {
            Name = name;
            Price = price;
            IsNew = true;
        }
    }
}
