using System;
using System.Collections.Generic;
using System.Text;

namespace Kata.CustomTypes.MenuItemVariantFactory
{
    public class FoodMenuItemVariant : MenuItemVariantBase
    {
        private string name;
        private decimal price;

        public FoodMenuItemVariant(string name, decimal price)
        {
            this.name = name;
            this.price = price;
        }
    }
}
