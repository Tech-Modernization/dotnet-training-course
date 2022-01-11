using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjectLayer.Extensions
{
    public class CleverDictionary: Dictionary<string, string>
    {
        [Flags]
        public enum LookupFlags
        {
            None = 0,
            CaseBlind = 1,
            SpaceBlind = 1 << 1,
            NoMatches = 1 << 2,
            UniqueMatch = 1 << 3,
            MultipleMatches = 1 << 4,
            StartsWith = 1 << 5,
            EndsWith = 1 << 6,
            ValueMatch = 1 << 7,
            Contains = 1 << 8
        }

        public class LookupState
        {
            public string KeySearchTerm;
            public string ValueSearchTerm;
            public List<string> KeyMatches;
            public List<string> ValueMatches;
            public string Key;
            public string Value;
            public LookupFlags Result;
        }

        public string this[Tuple<string> keyWrapper]
        {
            get => this.SingleOrDefault(kvp => kvp.Key == keyWrapper.Item1).Value;
        }

        public LookupState this[string term, LookupFlags flags=LookupFlags.StartsWith|LookupFlags.CaseBlind|LookupFlags.SpaceBlind]
        {
            get
            {
                term = ApplySearchFlags(term, flags);

                var resultFlags = flags.HasFlag(LookupFlags.ValueMatch) ? LookupFlags.ValueMatch : LookupFlags.None;
                var matches = flags.HasFlag(LookupFlags.ValueMatch)
                    ? this.Where(kvp => MatchByFlags(term, ApplySearchFlags(kvp.Value.ToString(), flags), flags, ref resultFlags))
                    .Select(kvp => kvp.Key).ToList()
                    : Keys.Where(k => MatchByFlags(term, ApplySearchFlags(k.ToString(), flags), flags, ref resultFlags)).ToList();

                switch (matches.Count)
                {
                    case 0:
                        resultFlags |= LookupFlags.NoMatches;
                        break;
                    case 1:
                        resultFlags |= LookupFlags.UniqueMatch;
                        break;
                    default:
                        resultFlags |= LookupFlags.MultipleMatches;
                        break;
                }
                
                var state = new LookupState
                {
                    KeyMatches = flags.HasFlag(LookupFlags.ValueMatch) ? null : matches,
                    ValueMatches = flags.HasFlag(LookupFlags.ValueMatch) ? matches.Select(m => this[m.Wrap()]).ToList() : null,
                    Key = matches.Count == 1 ? matches.First() : default,
                    Value = matches.Count == 1 ? this[matches.First().Wrap()] : default,
                    KeySearchTerm = flags.HasFlag(LookupFlags.ValueMatch) ? null : term,
                    ValueSearchTerm = flags.HasFlag(LookupFlags.ValueMatch) ? term : null,
                    Result = resultFlags
                };

                return state;
            }
        }

        private bool MatchByFlags(string term, string keyOrValue, LookupFlags flags, ref LookupFlags refFlags)
        {
            var result = term == keyOrValue;

            if (flags.HasFlag(LookupFlags.StartsWith))
            { 
                var startsWith = keyOrValue.StartsWith(term);
                refFlags |= startsWith ? LookupFlags.StartsWith : LookupFlags.None;
                result = result || startsWith;
            }

            if (flags.HasFlag(LookupFlags.Contains))
            {
                var contains = keyOrValue.Contains(term);
                refFlags |= contains ? LookupFlags.Contains : LookupFlags.None;
                result = result || contains;
            }
            
            if (flags.HasFlag(LookupFlags.EndsWith))
            {
                var endsWith = keyOrValue.EndsWith(term);
                refFlags |= endsWith ? LookupFlags.EndsWith : LookupFlags.None;
                result = result || endsWith;
            }

            return result;
        }

        private string ApplySearchFlags(string term, LookupFlags flags)
        {
            if (flags.HasFlag(LookupFlags.CaseBlind))
                term = term.ToLower();
            if (flags.HasFlag(LookupFlags.SpaceBlind))
                term = term.Replace(" ", "");

            return term;
        }
    }
}
