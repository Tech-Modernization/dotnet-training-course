using System;
using System.Collections.Generic;
using System.Text;

namespace Kata.CustomTypes.DressgammonFactory
{
    public class BackgammonCounter : PieceBase
    {
        public bool IsOnRail { get; set; }
        public BackgammonCounter(PieceColour colour) : base("Backgammon Counter", colour)
        {
        }
    }
}
