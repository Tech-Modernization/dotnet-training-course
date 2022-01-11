using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessObjectLayer.Gamependium
{
    public abstract class PieceBase
    {
        public string Name { get; }
        public PieceColour Colour { get; }
        protected PieceMove MoveFlags { get; set; }
        protected abstract IPieceMover Mover { get; }
        protected PieceBase(string name, PieceColour colour)
        {
            Name = name;
            Colour = colour;
        }
        public void MoveTo(IResetter board, int xpos, int ypos) 
        {
            var pp = new PiecePosition(xpos, ypos);
            var boardImp = board as BoardBase;
            boardImp[pp] = this;
        }
        public T Concrete<T>() where T : PieceBase => this as T;


    }
}
