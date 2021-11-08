using System;
using System.Collections.Generic;
using System.Text;

namespace Kata.Helpers
{
    public class MenuItemBase 
    {
        public MenuItemBase(int index, string text)
        {
            Index = index;
            Text = text;
        }

        public int Index { get; }
        public string Text { get; }
    }
}
