using System;
using System.Collections.Generic;
using System.Text;

namespace Kata.CustomTypes.MenuFactoryDic
{
    public struct MenuItemVariant<T1, T2>
    {
        public T1 FirstVariant;
        public T2 SecondVariant;
        public MenuItemVariant(T1 first, T2 second)
        {
            FirstVariant = first;
            SecondVariant = second;
        }

    }
}
