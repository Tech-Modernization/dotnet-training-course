using System;
using System.Collections.Generic;
using System.Text;

namespace Kata.CustomTypes.DressgammonFactory
{
    public abstract class PieceSetBase : List<PieceBase>
    {
        protected int PieceCount;
        protected PieceColour Colour;

        protected PieceSetBase(PieceColour colour, int pieceCount)
        {
            PieceCount = pieceCount;
            Colour = colour;
            CreatePieces();
        }

        public abstract void CreatePieces();
    }
}
