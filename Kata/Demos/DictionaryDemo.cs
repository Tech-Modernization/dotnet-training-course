using System;
using System.Collections.Generic;
using System.Text;

namespace Kata.Demos
{
    public class DictionaryDemo<TKey, TValue> : IDemo, IDictionaryDemo<TKey, TValue>
    {
        private Dictionary<TKey, TValue> dictionary = new Dictionary<TKey, TValue>();

        public void Run()
        {
            foreach(var entry in dictionary)
            {
                Console.WriteLine($"Key: {entry.Key},  Value: {entry.Value}");
            }
        }

        public TValue Search(TKey key)
        {
            if (dictionary.Count == 0)
            {
                Console.WriteLine($"There aren't entries to search.");
                return default;
            }

            return dictionary.ContainsKey(key) ? dictionary[key] : default;
        }

        public void Setup(TKey key, TValue val)
        {
            dictionary.TryAdd(key, val);
        }
    }
}
