using System;
using System.Collections.Generic;
using System.Text;

namespace Kata.CustomTypes.Gamependium
{
    public class DraughtsPiece : PieceBase, ITakeable
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

        public TakeResult TakePiece(bool overridePrevention = false)
        {
            throw new NotImplementedException();
        }

        public TakeResult TakePrevented()
        {
            throw new NotImplementedException();
        }

        protected override IPieceMover Mover { get; }
    }
}
