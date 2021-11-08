using System;
using System.Collections.Generic;
using System.Text;

namespace Kata.CustomTypes.Extensions
{
    public static class String
    {
        public static string Repeat(this string source, int repetitions)
        {
            var sb = new StringBuilder();
            for (var i = 0; i <= repetitions; i++)
                sb.Append(source);
            return sb.ToString();
        }
    }
}
