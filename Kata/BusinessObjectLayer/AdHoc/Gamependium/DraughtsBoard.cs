using System;
using System.Collections.Generic;
using System.Text;

using Kata.CustomTypes.Extensions;

namespace Kata.CustomTypes.Gamependium
{
    public class DraughtsBoard : BoardBase, IResetter
    {
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
                    var placePiece = isValidSquare && (colour == PieceColour.White ? y < 4 : y > 5);
                    if (!placePiece) continue;
                    var piece = Pieces[colour][idx++];
                    Console.WriteLine($"Placing {colour} at {x},{y}");
                    piece?.MoveTo(this, x, y);
                }
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            var outerHoz = $"+{new string('-', 5)}".Repeat(8) + "+";
            var innerHoz = outerHoz.Replace("+", "|").Replace("-", " ");

            for (var y = 1; y <= 8; y++)
            {
                sb.AppendLine(outerHoz);
                sb.AppendLine(innerHoz);
                for (var x = 1; x <= 8; x++)
                {
                    sb.Append(this[x, y] != null ? this[x, y].Colour == PieceColour.White ? "|  O  " : "|  X  " : "|     ");
                }
                sb.AppendLine("|");
                sb.AppendLine(innerHoz);
            }
            sb.AppendLine(outerHoz);

            return sb.ToString();
        }
    }
}
