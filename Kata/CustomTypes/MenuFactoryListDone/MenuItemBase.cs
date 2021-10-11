using System.Collections.Generic;

namespace Kata.CustomTypes.MenuFactoryListDone
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
            this.AddVariant(name, price);
        }
        protected virtual void AddVariant(string name, decimal price)
        {
            Variants.Add(new MenuItemVariant(name, price));
        }
    }
}