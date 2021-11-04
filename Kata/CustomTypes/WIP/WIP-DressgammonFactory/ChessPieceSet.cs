using System;
using System.Collections.Generic;
using System.Text;

namespace Kata.CustomTypes.DressgammonFactory
{
    public class ChessPieceSet : PieceSetBase
    {
        private List<string> monarchs = new List<string>() { "King", "Queen" };
        private List<string> courtiers = new List<string>() { "Bishop", "Knight", "Rook" };
        private const string pawn = "Pawn";

        public ChessPieceSet(PieceColour colour) : base(colour, 16)
        {
        }

        public override void CreatePieces()
        {
            foreach(var m in monarchs)
            {
                Add(new ChessPiece($"{m}", Colour));
                Add(new ChessPiece($"{m}{pawn}", Colour));
                foreach (var c in courtiers)
                {
                    Add(new ChessPiece($"{m}{c}{pawn}", Colour));
                    Add(new ChessPiece($"{m}{c}", Colour));
                }
            }
        }
    }
}
