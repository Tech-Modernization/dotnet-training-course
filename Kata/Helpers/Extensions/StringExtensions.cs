using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Helpers
{
    public static class StringExtensions
    {
        public static string Pluralise(this string noun, int quantity, string suffix = "s")
        {
            return $"{noun}{(quantity == 1 ? "" : suffix)}";
        }

        public static int ToInteger(this string source, int defaultValue = -1)
        {
            var asInt = 0;
            return int.TryParse(source, out asInt) ? asInt : defaultValue;
        }
    }
}
