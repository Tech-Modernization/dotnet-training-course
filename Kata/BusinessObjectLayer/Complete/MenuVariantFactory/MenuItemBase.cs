using System;
using System.Collections.Generic;
using System.Linq;

namespace BusinessObjectLayer.MenuFactoryListDone
{
    public abstract class MenuItemBase
    {
        public string Name { get; set; }
        protected List<MenuItemVariant> Variants { get; }
        protected abstract void CreateVariants();

        public MenuItemBase()
        {
            Variants = new List<MenuItemVariant>();
        }
        public MenuItemBase(string name, decimal price) : this()
        {
            Name = name;
            AddVariant(name, price);
        }
        protected virtual void AddVariant(string name, decimal price)
        {
            if (Variants.Any(variant => variant.Name == name && variant.Price == price))
            {
                // duplicate variant
                Console.WriteLine($"Ignoring duplicate {Name} variant [{name},{price:C}]");
                return;
            }

            Variants.Add(new MenuItemVariant(name, price));
        }
    }
}