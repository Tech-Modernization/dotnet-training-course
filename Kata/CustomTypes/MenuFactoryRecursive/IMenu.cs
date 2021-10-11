using System;
using System.Collections.Generic;
using System.Text;

namespace Kata.CustomTypes.MenuFactoryRecursive
{
    public interface IMenu
    {
        void AddItem(string name, SizeVariant size, decimal price);
    }
}
