using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Helpers
{
    public abstract class MenuBase : IEnumerable
    {
        public abstract List<MenuItemBase> Options { get; }

        public abstract IEnumerator GetEnumerator();
    }
}
