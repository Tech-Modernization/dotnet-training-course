using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

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

        public static List<string> SplitByAny(this string source, Func<char, bool> splitter)
        {
            var result = new List<string>();
            var savedPos = 0;
            for(var c = 0; c < source.Length; c++)
            {
                if (splitter(source[c]))
                {
                    result.Add(source.Substring(savedPos, c - savedPos));
                    savedPos = c;
                }
            }
            result.Add(source.Substring(savedPos));
            return result;
        }

        public static string Centre(this string source, int length)
        {
            var startPos = length / 2 - source.Length / 2;
            var result = new string(' ', length);
            return result.Overwrite(startPos, source);
        }

        public static string Centre(this string source, string lengthGuide)
        {
            var startPos = lengthGuide.Length / 2 - source.Length / 2;
            return lengthGuide.Overwrite(startPos, source);
        }

        public static Tuple<string> Wrap(this string source)
        {
            return new Tuple<string>(source);
        }

    }
}
