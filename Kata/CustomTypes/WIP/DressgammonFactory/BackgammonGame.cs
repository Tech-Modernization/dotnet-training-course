using System;
using System.Collections.Generic;
using System.Text;

namespace Kata.CustomTypes.DressgammonFactory
{
    public class BackgammonGame : GameBase
    {
        public Dice Dice = new Dice(2);
        protected override void CreatePieceSets()
        {
            Sets.Add(new BackgammonPieceSet(PieceColour.White));
            Sets.Add(new BackgammonPieceSet(PieceColour.Black));
        }

        protected override void CreateBoard()
        {
            Board = new BackgammonBoard();
        }

        public override void Display()
        {
            var sb = new StringBuilder();
            var outerHoz = string.Format("+{0}+", new string('-', 22));
            var innerHoz = outerHoz.Replace("+", "|").Replace("-", " ");
            var rail = outerHoz.Replace("-", "=");
            var board = Board as BackgammonBoard;
            board.Reset();

            for (var y = 1; y <= board.Length; y++)
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

