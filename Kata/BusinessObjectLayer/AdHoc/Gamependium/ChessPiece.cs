using System;
using System.Collections.Generic;
using System.Text;

namespace Kata.CustomTypes.Gamependium
{
    public class ChessPiece : PieceBase, ITakeable
    {
        public ChessPiece(string name, PieceColour colour) : base(name, colour)
        {
            SetMoveFlags(name);
        }

        public TakeResult TakePiece(bool overridePrevention = false)
        {
            throw new NotImplementedException();
        }

        public TakeResult TakePrevented()
        {
            throw new NotImplementedException();
        }

        void SetMoveFlags(string name)
        {
            switch (name)
            {
                case "King":
                    MoveFlags = PieceMove.Forward | PieceMove.Backward | PieceMove.Left | PieceMove.Right
                        | PieceMove.Single | PieceMove.Diagonal | PieceMove.Vertical | PieceMove.Horizontal
                        | PieceMove.Untakeable;
                    break;
                case "Pawn":
                    MoveFlags = PieceMove.Forward | PieceMove.Single | PieceMove.Diagonal;
                    break;
                case "Queen":
                    MoveFlags = PieceMove.Horizontal | PieceMove.Vertical | PieceMove.Diagonal
                        | PieceMove.Forward | PieceMove.Backward | PieceMove.Multi;
                    break;
                default:
                    if (name.EndsWith("Knight"))
                    {
                        MoveFlags = PieceMove.Horizontal | PieceMove.Vertical | PieceMove.Box3x2;
                    }
                    if (name.EndsWith("Bishop"))
                    {
                        MoveFlags = PieceMove.Diagonal | PieceMove.Forward | PieceMove.Backward | PieceMove.Multi;
                    }
                    if (name.EndsWith("Rook"))
                    {
                        MoveFlags = PieceMove.Horizontal | PieceMove.Vertical | PieceMove.Forward | PieceMove.Backward | PieceMove.Multi;
                    }
                    break;
            }
        }

        protected override IPieceMover Mover { get; }
    }
}
