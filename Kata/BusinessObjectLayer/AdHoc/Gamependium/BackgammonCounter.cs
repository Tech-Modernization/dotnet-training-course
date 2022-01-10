﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Kata.CustomTypes.Gamependium
{
    public class BackgammonCounter : PieceBase
    {
        public bool IsOnRail { get; set; }
        public BackgammonCounter(PieceColour colour) : base("Backgammon Counter", colour)
        {
        }

        protected override IPieceMover Mover { get; }
    }
}
