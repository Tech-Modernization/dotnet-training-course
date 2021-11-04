using System;
using System.Collections.Generic;
using System.Text;


namespace Kata.CustomTypes.DressgammonFactory
{
    public class DraughtsGame : GameBase
    {
        protected override void CreatePieceSets()
        {
            Sets.Add(new DraughtsPieceSet(PieceColour.White));
            Sets.Add(new DraughtsPieceSet(PieceColour.Black));
        }

        protected override void CreateBoard()
        {
            Board = new DraughtsBoard();
            Board.Initialise(Sets);
        }

        public override void Display()
        {
            var sb = new StringBuilder();
            var outerHoz = string.Format("+{0}+{0}+{0}+{0}+{0}+{0}+{0}+{0}+", new string('-', 3));
            var innerHoz = outerHoz.Replace("+", "|").Replace("-", " ");
            var board = Board as DraughtsBoard;
            board.Reset();
            for (var y = 1; y <= 8; y++)
            {
                sb.AppendLine(outerHoz);
                sb.AppendLine(innerHoz);
                for (var x = 1; x <= 8; x++)
                {
                    var pos = new PiecePosition(x, y);
                    sb.Append(board[pos] != null ? "| O " : "|   ");
                }
                sb.AppendLine("|");
                sb.AppendLine(innerHoz);
            }
            sb.AppendLine(outerHoz);

            Console.WriteLine(sb.ToString());
        }
    }
}
