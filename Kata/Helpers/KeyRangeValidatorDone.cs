using System;
using System.Collections.Generic;
using System.Text;

namespace Kata.Helpers
{
    public class KeyRangeValidatorDone : RangeValidatorDone
    {
        private Dictionary<ConsoleKey, int> map = new Dictionary<ConsoleKey, int>();
        public KeyRangeValidatorDone(int lowerBound, int upperBound) : base(lowerBound, upperBound)
        {
            for(var i = lowerBound; i <= upperBound; i++)
            {
                map.Add((ConsoleKey)i + 48, i);
            }
        }

        public bool IsValid(ConsoleKey key)
        {
            return map.ContainsKey(key);
        }
    }
}
