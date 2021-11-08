using System;
using System.Collections.Generic;
using System.Text;

namespace Kata.Helpers
{
    public class MenuItemWithAction<TParam1, TParam2, TParam3> : MenuItemWithAction<TParam1, TParam2>
    {
        public MenuItemWithAction(int index, string text, Action run) : base(index, text, run)
        {
        }
    }
    public class MenuItemWithAction<TParam1, TParam2> : MenuItemWithAction<TParam1>
    {
        public MenuItemWithAction(int index, string text, Action run) : base(index, text, run)
        {
        }
    }
    public class MenuItemWithAction<TParam1> : MenuItemWithAction
    {
        public MenuItemWithAction(int index, string text, Action run) : base(index, text, run)
        {
        }

    }

    public class MenuItemWithAction : MenuItemBase
    {
        public Action Run { get; }
        public MenuItemWithAction(int index, string text, Action run) : base(index, text)
        {
            Run = run;
        }
    }
}
