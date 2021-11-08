using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Kata.CustomTypes.DressgammonFactory
{
    public class BackgammonBoard : BoardBase, IGameBoard
    {
        public List<BackgammonCounter> Rail = new List<BackgammonCounter>();
        public List<BackgammonCounter> Off = new List<BackgammonCounter>();
        public BackgammonBoard() : base(24, 5)
        {
        }

        public override void Reset()
        {
            var whiteFill = new int[4, 2] { { 1, 2 }, { 7, 3 }, { 13, 5 }, { 19, 5 } };
            var blackFill = new int[4, 2] { { 24, 2 }, { 17, 3 }, { 12, 5 }, { 6, 5 } };
            var idx = 0;
            for (var colour = PieceColour.White; colour < (PieceColour) 2; colour++)
            {
                var fill = colour == PieceColour.White ? whiteFill : blackFill;
                for (var row = 0; row < fill.Length; row++)
                {
                    var rowPop = fill[row, 1];
                    for (var p = 0; p < rowPop; p++)
                    {
                        var piece = Pieces[PieceColour.White][idx];
                        this[new PiecePosition(row + 1, p + 1)] = piece;
                        piece.MoveTo(this, row + 1, p + 1);
                        Console.WriteLine($"Placing {colour} at {row + 1},{p + 1}");
                    }
                }
            }
        }
    }
}
