using System;
using System.Collections.Generic;
using System.Text;

namespace Kata.CustomTypes.Extensions
{
    public static class String
    {
        public static string Repeat(this string source, int repetitions, bool repsIsTotalOccurrences = true)
        {
            var sb = new StringBuilder();
            for (var i = 0; i <= repetitions - (repsIsTotalOccurrences ? 1 : 0); i++)
                sb.Append(source);
            return sb.ToString();
        }

        public static string Overwrite(this string source, int startPos, string replacementString)
        {
            return source.Remove(startPos, replacementString.Length).Insert(startPos, replacementString);
        }
    }
}
