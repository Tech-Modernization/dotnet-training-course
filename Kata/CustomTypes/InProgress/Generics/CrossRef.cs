using System;
using System.Collections.Generic;
using System.Text;

namespace Kata.CustomTypes
{
    public class CrossRef<T>
    {
        private List<T> items;
        public string Band;
        public CrossRef(params T[] items)
        {
            this.items = new List<T>(items);
        }

        public bool Find(T item)
        {
            return items.Contains(item);
        }
    }
}
