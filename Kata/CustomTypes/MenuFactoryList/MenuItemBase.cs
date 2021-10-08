using System.Collections.Generic;

namespace Kata.CustomTypes.MenuFactoryList
{
    public abstract class MenuItemBase
    {
        public string Name { get; set; }
        protected List<MenuItemVariant> Variants { get; }
        protected abstract void CreateVariants();
        protected virtual void AddVariant(string name, decimal price)
        {
            Variants.Add(new MenuItemVariant(name, price));
        }
        public MenuItemBase()
        {
            Variants = new List<MenuItemVariant>();
        }
        public MenuItemBase(string name, decimal price)
        {
            Variants = new List<MenuItemVariant>();
            Name = name;
            this.AddVariant(name, price);
        }
    }
}