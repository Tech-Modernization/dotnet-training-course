using System;
using System.Collections.Generic;
using System.Text;

namespace Kata.CustomTypes.DressgammonFactory
{
    public abstract class PieceBase
    {
        public string Name { get; }
        public PieceColour Colour { get; }
        protected PieceMove MoveFlags { get; set; }
        protected PieceBase(string name, PieceColour colour)
        {
            Name = name;
            Colour = colour;
        }

        public void MoveTo(IGameBoard board, int xpos, int ypos) 
        {
            var pp = new PiecePosition(xpos, ypos);
            var boardImp = board as BoardBase;
            boardImp[pp] = this;
        }

    }
}
