
using System.Collections.Generic;
using System.Linq;

namespace Helpers
{
    public static class SetHelper
    {
        public static bool InSet<T>(T val, List<T> valList)
        {
            return valList.Contains(val);
        }
        public static bool InSet<T>(T val, params T[] valList)
        {
            return valList.Contains(val);
        }
    }
}
