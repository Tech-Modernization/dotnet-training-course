using System;
using System.Collections.Generic;
using System.Text;

namespace Helpers
{
    public class MenuOptionBase
    {
        public string Text;
        public string Index;

        public MenuOptionBase(string text, string index)
        {
            Text = text;
            Index = index;
        }
    }

}
