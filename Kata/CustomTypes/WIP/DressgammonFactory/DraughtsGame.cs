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
            var outerHoz = string.Format("+{0}+{0}+{0}+{0}+{0}+{0}+{0}+{0}+", new string('-', 5));
            var innerHoz = outerHoz.Replace("+", "|").Replace("-", " ");
            var board = Board as DraughtsBoard;
            board.Reset();
            for (var y = 1; y <= 8; y++)
            {
                sb.AppendLine(outerHoz);
                sb.AppendLine(innerHoz);
                for (var x = 1; x <= 8; x++)
                {
                    sb.Append(board[x, y] != null ? board[x, y].Colour == PieceColour.White ? "|  O  " : "|  X  " : "|     ");
                }
                sb.AppendLine("|");
                sb.AppendLine(innerHoz);
            }
            sb.AppendLine(outerHoz);

            Console.WriteLine(sb.ToString());
        }
    }
}
