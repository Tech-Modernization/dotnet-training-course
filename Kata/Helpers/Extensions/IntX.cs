using System;
using System.Collections.Generic;
using System.Text;

namespace Helpers
{
    public static class IntX
    {
        public static bool Between(this int target, int low, int high, bool inclusive = true)
        {
            return inclusive ? target <= high && target >= low : target > low && target < high;
        }

        public static int MidPoint(this int source, bool lateEven = false)
        {
            var evenModulo = source % 2;
            return evenModulo == 0 ? lateEven ? source / 2 + 1 : source / 2 : ((source - evenModulo) / 2) + 1;
        }
    }
}
