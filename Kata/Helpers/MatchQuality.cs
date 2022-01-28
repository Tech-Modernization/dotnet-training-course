using System;
using System.Collections.Generic;
using System.Text;

namespace Helpers
{
    [Flags]
    public enum MatchQuality
    {
        None = 0,
        Exact = 1, 
        SpaceBlindExact = 1 << 1, 
        CaseBlindExact = 1 << 2, 
        Length = 1 << 3, 
        SpaceBlindLength = 1 << 4, 
        WordMatch = 1 << 5, 
        ArticleBlindExact = 1 << 6,
        ArticleBlindWordMatch = 1 << 7, 
        ArticleBlindCharMatch = 1 << 8,
        AlphabeticalOrderExact = 1 << 9,
        AlphabeticalOrderPartial = 1 << 10,
        AlphabeticalOrderAlmostExact = 1 << 11
    }
}
