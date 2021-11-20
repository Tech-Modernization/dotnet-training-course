using System;
using System.Collections.Generic;
using System.Text;

namespace Kata.CustomTypes.Demo.Gamependium
{
    public class DraughtsPiece : PieceBase
    {
        public bool IsKing { get => MoveFlags.HasFlag(PieceMove.Backward); }
        public DraughtsPiece(PieceColour colour) : base("Draught", colour)
        {
            MoveFlags = PieceMove.Forward | PieceMove.Diagonal | PieceMove.Single;
        }

        public void MakeKing()
        {
            MoveFlags |= PieceMove.Backward;
        }


    }
}
