using System;
using System.Collections.Generic;
using System.Text;


namespace Kata.CustomTypes.DressgammonFactory
{
    public class DraughtsGame : GameBase
    {
        protected override void CreatePieceSets()
        {
            Sets.Add(new DraughtsPieceSet(PieceColour.White));
            Sets.Add(new DraughtsPieceSet(PieceColour.Black));
        }

        protected override void CreateBoard()
        {
            Board = new DraughtsBoard();
            Board.Initialise(Sets);
            Board.Reset();
        }
    }
}
