using System;
using System.Collections.Generic;
using System.Text;

namespace Kata.CustomTypes.DressgammonFactory
{
    public class TakeResult<T>
    {
        public PiecePosition ThreatPosition { get; }
        public T ThreateningPiece { get; } 
    }
}
