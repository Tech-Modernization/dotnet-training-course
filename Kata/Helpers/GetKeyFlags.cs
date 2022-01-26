using System;

namespace Helpers
{
    [Flags]
    public enum GetKeyFlags
    {
        AddQuit = 1,
        NoNewLine = 1 << 1,
        YesNo = 1 << 2
    }
}