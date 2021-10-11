using System;
using System.Collections.Generic;
using System.Text;

namespace Kata.CustomTypes.MenuFactoryDic
{
    public class MenuItemVariant : MenuItemVariant<DefaultVariant, DefaultVariant>
    {
        public MenuItemVariant() : base(DefaultVariant.Default, DefaultVariant.Default)
        {
        }
    }
    public class MenuItemVariant<T1, T2>
    {
        public T1 FirstVariant { get; set; }
        public T2 SecondVariant { get; set; }

        public MenuItemVariant(T1 first, T2 second)
        {
            FirstVariant = first;
            SecondVariant = second;
        }

        public override string ToString()
        {
            var firstFmt = $"{FirstVariant}";
            var secondFmt = $"({SecondVariant})";
            return $"    {firstFmt,-40} {secondFmt,-15}";
        }
    }
}
