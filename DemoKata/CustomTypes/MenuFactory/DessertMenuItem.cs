using System;
using System.Collections.Generic;
using System.Text;

namespace CustomTypes.MenuFactory
{
    public enum IceCreamFlavour {  Chocolate, Van}
    public class DessertMenuItem : MenuItemBase
    {
        protected bool glutenFree;
        public IceCreamFlavour Flavour;

        public DessertMenuItem(string name, decimal price)
        {
            Name = name;
            Price = price;
        }
    }
}
