using System;
using System.Collections.Generic;
using System.Text;

namespace Kata.CustomTypes.MenuFactoryList
{
    public class FoodMenuItem : MenuItemBase
    {
        public FoodMenuItem(string name, decimal price) : base(name, price)
        {
        }
    }
}
