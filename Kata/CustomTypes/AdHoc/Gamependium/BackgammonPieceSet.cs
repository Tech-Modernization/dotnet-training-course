using System;
using System.Collections.Generic;
using System.Text;

namespace Kata.CustomTypes.Gamependium
{
    public class BackgammonPieceSet : PieceSetBase
    {
        public BackgammonPieceSet(PieceColour colour) : base(colour, 15)
        {
        }

        public override void CreatePieces()
        {
            for(var i = PieceCount; i > 0; i--)
            {
                Add(new BackgammonCounter(Colour));
            }
        }
    }
}
