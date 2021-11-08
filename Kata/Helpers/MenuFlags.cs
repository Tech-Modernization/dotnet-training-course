using System;
using System.Collections.Generic;
using System.Text;

namespace Kata.Helpers
{
    [Flags]
    public enum MenuFlags
    {
        ClearScreenFirst = 1,
        SelectWithReadKey = 1 << 1,
        GenerateExitOption = 1 << 2
    };
}
