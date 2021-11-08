using System;
using System.Collections.Generic;
using System.Text;

namespace Kata.Helpers
{
    public class MenuItemWithFunc<TParam1, TReturn> : MenuItemBase
    {
        public Func<TParam1, TReturn> Call;
        public MenuItemWithFunc(int index, string text) : base(index, text)
        {
        }
    }
    public class MenuItemWithFunc<TParam1, TParam2, TReturn> : MenuItemBase
    {
        public Func<TParam1, TParam2, TReturn> Call;
        public MenuItemWithFunc(int index, string text) : base(index, text)
        {
        }
    }
    public class MenuItemWithFunc<TParam1, TParam2, TParam3, TReturn> : MenuItemBase
    {
        public Func<TParam1, TParam2, TParam3, TReturn> Call;
        public MenuItemWithFunc(int index, string text) : base(index, text)
        {
        }
    }

    public class MenuItemWithFunc<TReturn> : MenuItemBase
    {
        public MenuItemWithFunc(int index, string text, Func<TReturn> call) : base(index, text)
        {
            Call = call;
        }

        public Func<TReturn> Call { get; set; }
    }
}
