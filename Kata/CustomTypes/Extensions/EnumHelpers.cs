using System;
using System.Collections.Generic;
using System.Linq;

namespace CustomTypes.Extensions
{
    public static class EnumHelpers
    {
        public static bool Contains<T>(T sampleEnum, int enumVal)
        {
            if (!typeof(T).IsEnum) return false;

            var enumValues = new List<int>((int[])Enum.GetValues(typeof(T)));
            return enumValues.Contains(enumVal);
        }
    }
}
