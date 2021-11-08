using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Kata.CustomTypes.Extensions;

namespace Kata.CustomTypes.DressgammonFactory
{
    public class BackgammonGame : GameBase
    {
        public Dice Dice = new Dice(2);
        protected override void CreatePieceSets()
        {
            Sets.Add(new BackgammonPieceSet(PieceColour.White));
            Sets.Add(new BackgammonPieceSet(PieceColour.Black));
        }

        protected override void CreateBoard()
        {
            Board = new BackgammonBoard();
            Board.Initialise(Sets);
            Board.Reset();
        }
    }
}

