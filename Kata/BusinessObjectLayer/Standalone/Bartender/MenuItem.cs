using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessObjectLayer.Bartender
{
    // Responsibility: encapsulate the text reprensentation of a product and its price
    public class MenuItem
    {
        public string Text { get; }
        public decimal Price { get; }
        public MenuItem(string text, decimal price)
        {
            Text = text;
            Price = price;
        }
    }
}
