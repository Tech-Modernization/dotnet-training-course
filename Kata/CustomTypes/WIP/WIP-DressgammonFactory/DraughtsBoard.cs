using System;
using System.Collections.Generic;
using System.Text;

namespace Kata.CustomTypes.DressgammonFactory
{
    public class DraughtsBoard : BoardBase, IGameBoard
    {
        public override void Initialise(List<PieceSetBase> pieces)
        {
            base.Initialise();
            foreach(var p in pieces)
            {
                Pieces.TryAdd(p[0].Colour, p);
            }
            WhoseMove = PieceColour.White;
        }
        public override void Reset()
        {
            for (var y = 1; y <= Width; y++)
            {
                var colour = y < 4 ? PieceColour.White : PieceColour.Black;
                var idx = 0;
                for (var x = 1; x <= Length; x++)
                {
                    this[new PiecePosition(x, y)] = null;
                    var isWhite = colour == PieceColour.White;
                    var isMiddle = isWhite ? y == 2 : y == 7;
                    var isValidSquare = isWhite
                        ? isMiddle ? x % 2 == 0 : x % 2 == 1
                        : isMiddle ? x % 2 == 1 : x % 2 == 0;
                    var placePiece = isValidSquare && colour == PieceColour.White ? y < 4 : y > 5;
                    if (!placePiece) continue;
                    var piece = Pieces[colour][idx++];
                    piece?.MoveTo(this, x, y);
                }
            }
        }
    }
}
