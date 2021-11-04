using System;
using System.Collections.Generic;
using System.Linq;

namespace Kata.CustomTypes.MenuFactoryDic
{
    public abstract class MenuItemBase<T1, T2>
    {
        public string Name { get; set; }
        public decimal Price { get; set; }

        protected MenuItemVariantDictionary<T1, T2> Variants = new MenuItemVariantDictionary<T1, T2>();

        protected abstract void CreateVariants();

        public MenuItemBase()
        {
            CreateVariants();
        }
    }
}