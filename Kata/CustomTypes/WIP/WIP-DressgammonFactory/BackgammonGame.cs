using System;
using System.Collections.Generic;
using System.Text;

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
        }

        public override void Display()
        {
            throw new NotImplementedException();
        }
    }
}
