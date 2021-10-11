using System;
using System.Collections.Generic;
using System.Text;

namespace Kata.CustomTypes.MenuFactoryList
{
    public class DrinksMenuItem : MenuItemBase
    {
        public DrinksMenuItem(string name, ref decimal price) : base(name, price)
        {
            price *= 2;
            Console.WriteLine($"Receiving {name} @ double the price: {price:C}");
        }
    }


}
