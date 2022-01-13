using System.Collections.Generic;

namespace Helpers
{
    public class HelperMenuItems : Dictionary<int, string>
    {
        public void Add(string itemText)
        {
            TryAdd(Count + 1, itemText);
        }
    }
}