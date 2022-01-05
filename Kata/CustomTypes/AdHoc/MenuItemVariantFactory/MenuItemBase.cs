using System;
using System.Collections.Generic;
using System.Text;

namespace Kata.CustomTypes.MenuItemVariantFactory
{
    public abstract class MenuItemBase
    {
        private List<MenuItemVariantBase> variants = new List<MenuItemVariantBase>();
        public List<MenuItemVariantBase> Variants { get => variants; }
        public MenuItemBase()
        {
            CreateVariants();
        }
        protected abstract void CreateVariants();
    }
}
