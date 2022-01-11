using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessObjectLayer.Gamependium
{
    public class DraughtsPieceSet : PieceSetBase
    {
        public DraughtsPieceSet(PieceColour colour) : base(colour, 12)
        {
        }

        public override void CreatePieces()
        {
            for(var i = 0; i < PieceCount; i++)
            {
                Add(new DraughtsPiece(Colour));
            }
        }
    }
}
