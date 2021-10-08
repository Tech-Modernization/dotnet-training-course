using System.Collections.Generic;

namespace Kata.CustomTypes.MenuFactoryDic
{
    public abstract class MenuItemBase
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public MenuItemBase()
        {
        }

    }
    public abstract class MenuItemBase<T1, T2> : MenuItemBase
    {
        protected abstract Dictionary<MenuItemVariant<T1, T2>, decimal> Variants { get; }

        protected abstract void AddVariant(T1 firstVar, T2 secondVar, decimal price);
    }
}