using System;
using System.Collections.Generic;
using System.Text;

namespace Kata.CustomTypes.MenuFactoryList
{
    public class DrinksMenuItem : MenuItemBase
    {
        public DrinksMenuItem(string name, decimal price) : base(name, price)
        {
        }
    }
}
