using System;
using System.Collections.Generic;
using System.Text;

namespace Kata.CustomTypes.DressgammonFactory
{
    [Flags]
    public enum PieceMove
    {
        Forward = 1,
        Backward = 1 << 1,
        Left = 1 << 2,
        Right = 1 << 3,
        Single = 1 << 4,
        Multi = 1 << 5,
        Box3x2 = 1 << 6,
        Horizontal = 1 << 7,
        Vertical = 1 << 8,
        Diagonal = 1 << 9,
        Untakeable = 1 << 10

    }
}
