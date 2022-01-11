using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

using BusinessObjectLayer.Extensions;

namespace BusinessObjectLayer.Gamependium
{
    public class ChessBoard : BoardBase, IResetter
    {
        public override void Reset()
        {
            for(var colour = PieceColour.Black; colour <= PieceColour.White; colour++)
            {
                var pawns = 8;
                foreach(var p in Pieces[colour])
                {
                    var xAxis = 0;
                    var yAxis = colour == PieceColour.White ? 1 : 8;
                    var tokens = p.Name.SplitByAny(c => char.IsUpper(c));
                    var pieceIdent = tokens.Last();
                    if (pieceIdent == "Pawn")
                    {
                        yAxis = colour == PieceColour.White ? 2 : 7;
                        xAxis = pawns--;
                    }

                    switch (pieceIdent)
                    {
                        case "King":
                        case "Queen":
                            xAxis = colour == PieceColour.White ? pieceIdent == "King" ? 5 : 4 : pieceIdent == "King" ? 4 : 5;
                            break;
                        case "Bishop":
                            xAxis = tokens[1] == "King" ? 3 : 6;
                            break;
                        case "Knight":
                            xAxis = tokens[1] == "King" ? 2 : 7;
                            break;
                        case "Rook":
                            xAxis = tokens[1] == "King" ? 1 : 8;
                            break;
                    }

                    this[new PiecePosition(xAxis, yAxis)] = p;
                }
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            var outerHoz = $"+{new string('-', 8)}".Repeat(8) + "+";
            var innerHoz = outerHoz.Replace("+", "|").Replace("-", " ");

            var whiteFooter = "W h i t e".Centre(outerHoz.Length);
            var blackHeader = "B l a c k".Centre(outerHoz.Length);

            var emptySquare = $"|{new string(' ', 8)}";
            sb.AppendLine(blackHeader);
            for (var y = 1; y <= Length; y++)
            {
                sb.AppendLine(outerHoz);
                sb.AppendLine(innerHoz);
                for (var x = 1; x <= Width; x++)
                {
                    var piece = this[x, y];
                    if (piece == null)
                    {
                        sb.Append(emptySquare);
                        continue;
                    }

                    sb.Append(this[x, y].Name.SplitByAny(c => char.IsUpper(c)).Last().Centre(emptySquare.Length));
                }
                sb.AppendLine("|");
                sb.AppendLine(innerHoz);
            }
            sb.AppendLine(outerHoz);
            sb.AppendLine(whiteFooter);
            return sb.ToString();
        }
    }
}
