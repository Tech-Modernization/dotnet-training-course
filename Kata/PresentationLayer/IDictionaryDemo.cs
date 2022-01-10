using System;
using System.Collections.Generic;
using System.Text;

namespace Kata.Demos
{
    public interface IDictionaryDemo<TKey, TValue>
    {
        void Setup(TKey key, TValue val);
        TValue Search(TKey key);
    }
}
