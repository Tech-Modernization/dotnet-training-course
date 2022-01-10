using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Kata.CustomTypes.Gamependium
{
    public class ChessGame : GameBase
    {
        public ChessGame(IPlayerService playerService) : base(playerService)
        {
        }

        protected override void CreatePieceSets()
        {
            Sets.Add(new ChessPieceSet(PieceColour.White));
            Sets.Add(new ChessPieceSet(PieceColour.Black));
        }

        protected override void CreateBoard()
        {
            Board = new ChessBoard();
            Board.Initialise(Sets);
            Board.Reset();
        }
    }
}
