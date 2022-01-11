using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessObjectLayer.Demo.LyricAnalyser
{

    [Flags]
    public enum MatchQualityFlags
    {
        None = 0, Exact = 1, Partial = 1 << 1, CaseBlind = 1 << 2
    }
}
