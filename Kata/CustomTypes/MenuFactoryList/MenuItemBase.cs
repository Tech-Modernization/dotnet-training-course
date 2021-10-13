using System;
using System.Collections.Generic;

namespace Kata.CustomTypes.MenuFactoryList
{
    public abstract class MenuItemBase
    {
        protected string Name { get; set; }
        protected decimal Price { get; set; }
        // 1. backing store
        private List<MenuItemVariant> variants = new List<MenuItemVariant>();
        // 2. property access
        public List<MenuItemVariant> Variants { get { return variants; } }
        // 3. constructor
        public MenuItemBase(string name, decimal price)
        {
            Name = name;
            Price = price;
            this.CreateVariants();
        }
        // 4. factory method
        protected abstract void CreateVariants();
    }
}
