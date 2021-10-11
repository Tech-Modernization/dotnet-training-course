using System;
using System.Collections.Generic;
using System.Text;

namespace Kata.CustomTypes.MenuFactoryDic
{
    public class DrinkMenuItemVariant<T> : MenuItemVariant<T, SizeVariant>
    {
        public T DrinkName { get; }
        public SizeVariant Size { get; }
        public DrinkMenuItemVariant(T drinkVar, SizeVariant size) : base(drinkVar, size)
        {
            DrinkName = FirstVariant;
            Size = SecondVariant;
        }
    }
}
