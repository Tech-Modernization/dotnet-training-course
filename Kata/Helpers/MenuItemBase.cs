using System;
using System.Collections.Generic;
using System.Text;

namespace Helpers
{
    public class MenuItemBase 
    {
        public int Index;
        public string Text;
        public Type ImplementedAs;
        public Action<Type> Run;
    }
}
