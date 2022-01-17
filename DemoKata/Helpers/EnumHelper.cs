using System;
using System.Collections.Generic;
using System.Linq;

namespace Helpers
{
    public static class EnumHelper
    {
        public static bool Contains<T>(T sampleEnum, int enumVal)
        {
            if (!typeof(T).IsEnum) return false;

            var enumValues = new List<int>((int[])Enum.GetValues(typeof(T)));
            return enumValues.Contains(enumVal);
        }

        [Flags]
        private enum GenericFlags { }
        public static List<TGroup> GetValuesWithFlag<TGroup, TFilter>(TFilter flag)
            where TGroup : Enum
            where TFilter : Enum
        {
            var groupValues = (GenericFlags[]) Enum.GetValues(typeof(TGroup));
            var igroupValues = groupValues.Select(val => Convert.ToInt32(val)).ToList();
            var iflag = Convert.ToInt32(flag);
            var eflag = (GenericFlags)iflag;
            var filterValues = groupValues.Where(gval => gval.HasFlag(eflag)).Select(val => (Enum) val).ToList();
            return filterValues.Select(fv => (TGroup)fv).ToList();
        }
    }
}
