using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Kata.CustomTypes.DressgammonFactory
{
    public class ChessGameBoard : GameBase
    {
        protected override void CreatePieceSets()
        {
            Sets.Add(new ChessPieceSet(PieceColour.White));
            Sets.Add(new ChessPieceSet(PieceColour.Black));
        }

        public override void Display()
        {
            throw new NotImplementedException();
        }

        protected override void CreateBoard()
        {
            Board = new ChessBoard();
            Board.Initialise(Sets);
        }
    }
}
