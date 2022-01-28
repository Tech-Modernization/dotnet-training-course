using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Globalization;

namespace Helpers
{
    public static class String
    {
        public static string Token(this string source, string delim, params int[] returnTokenIndex)
        {
            // use the count of tokens found as an index into the var args list 
            // to find the index of the token to return
            var tokens = source.Split(delim[0]);
            // if there are more tokens than provided for, return empty 
            if (tokens.Length > returnTokenIndex.Length) return string.Empty;
            // if the index to return is invalid (index out of bounds of token array) return empty
            var indexToReturn = returnTokenIndex[tokens.Length - 1];
            if (indexToReturn < 0 || indexToReturn > tokens.Length - 1) return string.Empty;
            return tokens[indexToReturn];
        }

        public static List<string> SplitEven(this string source, string delim, int maxLength)
        {

            var chars = source.ToList();
            var part2 = new List<char>();
            var splitPos = 0;
            for (var pos = chars.Count.MidPoint(); pos < chars.Count; pos++)
            {
                if (chars[pos] == delim[0] && splitPos == 0)
                {
                    splitPos = pos + 1;
                    continue;
                }

                if (splitPos == 0)
                {
                    if (chars[pos - 1] == delim[0])
                    {
                        splitPos = pos;
                        continue;
                    }

                    if (chars[pos + 1] == delim[0])
                    {
                        splitPos = pos + 2;
                        pos++;
                        continue;
                    }

                    pos -= 2;
                }

                part2.Add(chars[pos]);
            }

            var evenTokens = new List<string>() { source.Substring(0, splitPos), string.Join("", part2) };
            return evenTokens;
        }
        public static List<string> SplitEven(this string source, string delim, int maxLength, bool arse)
        {
            var tokens = source.Split(' ');
            var combo = string.Empty;
            var evenTokens = new List<string>();
            for (var i = 0; i < tokens.Length; i++)
            {
                var token = tokens[i];
                var isLastToken = i + 1 == tokens.Length;

                if (token.Length + combo.Length <= maxLength)
                {
                    if (combo.Length != 0) combo += " ";
                    combo += token;
                    continue;
                }

                evenTokens.Add(combo);
                combo = string.Empty;
                
                if (token.Length <= maxLength)
                {
                    continue;
                }

                // if this bit is too long, then hyphenate it, add it to the combo,
                // save the new token and start the next combo with the hyphenation
                var tokenChunks = token.SplitByAny(
                    c => "aeiou".Contains(c) 
                         && token.IndexOf(c)
                                 .Between(token.Length.MidPoint() - 2, token.Length.MidPoint() + 2)
                , true);

                var lastChunk = tokenChunks.Last();
                tokenChunks.Remove(lastChunk);
                var hyphA = $"{string.Join("", tokenChunks)}-";
                var hyphB = $"-{lastChunk}";
                if (hyphA.Length + combo.Length <= maxLength)
                {
                    combo += hyphA;
                    evenTokens.Add(combo);

                    if (isLastToken)
                    {
                        evenTokens.Add(hyphB);
                        continue;
                    }
                }


            }
            return evenTokens;
        }

        public static string Overwrite(this string source, int startPos, string replStr)
        {
            var front = source.Substring(0, startPos);
            var repLength = replStr.Length;
            if (startPos + repLength >= source.Length)
            {
                // truncate if too long
                replStr = replStr.Substring(0, source.Length / 2) + ".";
                repLength = replStr.Length;
                startPos = source.Length.MidPoint() - (repLength / 2);
            }

            var removed = source.Remove(startPos, repLength);
            return removed.Insert(startPos, replStr);
        }

        public static List<string> SplitByAny(this string source, Func<char, bool> splitter, bool preserveDelimiters)
        {
            var result = new List<string>();
            var savedPos = 0;
            for(var pos = 0; pos < source.Length; pos++)
            {
                if (splitter(source[pos]))
                {
                    result.Add(source.Substring(savedPos, pos - savedPos));
                    savedPos = pos + (preserveDelimiters ? 0 : 1); 
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

        public static Tuple<string> Wrap(this string source)
        {
            return new Tuple<string>(source);
        }

        public static MatchQuality IsMatch(this string source, string comparisonString, string delimiters = " ,-/", bool ignoreQuotes = true)
        {
            var mq = MatchQuality.None;
            if (ignoreQuotes) source = source.ReplaceAny("", "'", "\"");
            if (source == comparisonString) return MatchQuality.Exact;
            if (source.Length == comparisonString.Length) mq |= MatchQuality.Length;

            var caseBlind = source.ToLower();
            if (comparisonString.ToLower() == caseBlind) mq |= MatchQuality.CaseBlindExact;

            var spaceBlind = source.Collapse();
            if (spaceBlind.Length == comparisonString.Collapse().Length) mq |= MatchQuality.SpaceBlindLength;
            if (spaceBlind == comparisonString.Collapse()) mq |= MatchQuality.SpaceBlindExact;

            var artBlind = source.ToLower().ReplaceAny(" ", ", ", "the ", "a ", "an ");
            var compArtBlind = comparisonString.ToLower().ReplaceAny(" ", ", ", "the ", "a ", "an ");
            if (artBlind == compArtBlind) mq |= MatchQuality.ArticleBlindExact;

            var tokens = source.SplitByAny(delimiters.Select(c => c.ToString()).ToArray());
            var compTokens = comparisonString.SplitByAny(delimiters.Select(c => c.ToString()).ToArray());
            if (tokens.Count == compTokens.Count && tokens.All(t => compTokens[tokens.IndexOf(t)] == t)) mq |= MatchQuality.ArticleBlindWordMatch;

            mq |= spaceBlind.IsAlphaMatch(comparisonString.Collapse());

            if (tokens.Count == compTokens.Count && tokens.All(t =>
            {
                if (string.IsNullOrEmpty(t)) return false;
                var flags = t.IsAlphaMatch(compTokens[tokens.IndexOf(t)]);
                return flags.HasFlag(MatchQuality.AlphabeticalOrderExact) || flags.HasFlag(MatchQuality.AlphabeticalOrderAlmostExact);
            }))
            {
                mq |= MatchQuality.WordMatch;
            }

            return mq;
        }

        public static MatchQuality IsAlphaMatch(this string source, string comparisonString)
        {
            // if either length is zero, can't compare them.
            if (source.Length * comparisonString.Length == 0) return MatchQuality.None;

            // if the strings are of wildly different lengths, there's no way it's a reliable match
            var shorter = source.Length < comparisonString.Length ? source.Length : comparisonString.Length;
            var longer = source.Length > comparisonString.Length ? source.Length : comparisonString.Length;
            if (longer / shorter > 2.0) return MatchQuality.None;

            var mq = MatchQuality.None;
            var chars = source.ToCharArray().OrderBy(c => c).ToList();
            var compChars = comparisonString.ToCharArray().OrderBy(c => c).ToList();
            var maxComp = chars.Count < compChars.Count ? chars.Count : compChars.Count;

            for (var i = 0; i <= maxComp; i++)
            {
                if (i == maxComp)
                {
                    mq |= mq.HasFlag(MatchQuality.SpaceBlindLength) ? MatchQuality.AlphabeticalOrderExact : MatchQuality.AlphabeticalOrderAlmostExact;
                    break;
                }

                if (chars[i] == compChars[i])
                {
                    if (i * 100 / chars.Count > 30) mq |= MatchQuality.AlphabeticalOrderPartial;
                }
                else
                    break;
            }

            return mq;
        }
        public static string Collapse(this string source)
        {
            return source.Replace(" ", "").ToLower();
        }
        public static string ToTitleCase(this string source)
        {
            if (string.IsNullOrWhiteSpace(source)) return string.Empty;

            TextInfo ti = new CultureInfo("en-UK").TextInfo;
            return ti.ToTitleCase(source);
        }
        public static string Repeat(this string source, int repetitions, bool repsIsTotalOccurrences = true)
        {
            var sb = new StringBuilder();
            for (var i = 0; i <= repetitions - (repsIsTotalOccurrences ? 1 : 0); i++)
                sb.Append(source);
            return sb.ToString();
        }

        public static List<string> SplitByAny(this string source, params string[] delimiters)
        {
            var result = new List<string>();
            var savedPos = 0;
            for (var pos = 0; pos < source.Length; pos++)
            {
                if (delimiters.Contains(source[pos].ToString()))
                {
                    var token = source.Substring(savedPos, pos - savedPos);
                    if (string.IsNullOrWhiteSpace(token)) continue;

                    result.Add(token);
                    savedPos = pos + 1; // skip the delimiter
                }
            }
            result.Add(source.Substring(savedPos));
            return result;
        }

        public static string ReplaceDeep(this string source, string searchString, string replacementString)
        {
            source = source.Replace(searchString, replacementString);

            return source.Contains(searchString) ? source.ReplaceDeep(searchString, replacementString) : source;
        }

        public static string ReplaceAny(this string source, string replStr, params string[] strList)
        {
            foreach (var str in strList)
            {
                source = source.ReplaceDeep(str, replStr);
            }
            return source;
        }

        public static string Uncomma(this string source)
        {
            var tokens = source.Split(',');
            switch (tokens.Length)
            {
                case 1:
                    return source;
                case 2:
                    return $"{tokens[1].Trim()} {tokens[0].Trim()}";
                default:
                    var pos = source.IndexOfFirst(tokens.Last());
                    return $"{tokens.Last().Trim()} {source.Substring(0, pos - 1)}";
            }
        }

        public static int IndexOfFirst(this string source, string searchStr)
        {
            var char0 = searchStr[0];
            for (var i = 0; i < source.Length; i++)
            {
                if (source[i] == char0)
                {
                    var impliedLength = i + searchStr.Length;
                    var substr = (impliedLength > source.Length) ? source.Substring(i) : source.Substring(i, searchStr.Length);
                    if (substr == searchStr)
                    {
                        return i;
                    }
                }
            }
            return -1;
        }
        public static string ReplaceBlind(this string source, string searchStr, string replStr)
        {
            var searchStrLower = searchStr.ToLower();
            var workStr = source.ToString();
            do
            {
                var sourceLower = workStr.ToLower();
                var pos = sourceLower.IndexOfFirst(searchStrLower);
                if (pos < 0) return workStr;
                var part1 = workStr.Substring(0, pos);
                var part2 = workStr.Substring(pos + searchStr.Length);
                workStr = part1 + replStr + part2;
            }
            while (true);
        }

        public static bool In(this string source, params string[] list)
        {
            return list.ToList().Contains(source);
        }
    }


}
