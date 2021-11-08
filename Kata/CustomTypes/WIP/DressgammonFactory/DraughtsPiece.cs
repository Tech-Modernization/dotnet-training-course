using System;
using System.Collections.Generic;
using System.Text;

namespace Kata.CustomTypes.DressgammonFactory
{
    public class DraughtsPiece : PieceBase, ITakeable<DraughtsPiece>
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

        public TakeResult<DraughtsPiece> TakePiece(bool overridePrevention = false)
        {
            throw new NotImplementedException();
        }

        public TakeResult<DraughtsPiece> TakePrevented()
        {
            throw new NotImplementedException();
        }
    }
}
