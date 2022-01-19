using System;
using System.Collections.Generic;
using System.Text;

namespace Helpers.Extensions
{
    public static class StringExtensions
    {
        public static string Pluralise(this string noun, int quantity, string suffix = "s")
        {
            return $"{noun}{(quantity == 1 ? "" : suffix)}";
        }
    }
}
