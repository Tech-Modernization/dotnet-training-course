﻿
namespace Kata.CustomTypes.MenuFactoryVariant
{
    public abstract class MenuItemBase
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public abstract bool HasVariants { get; }
    }
}
