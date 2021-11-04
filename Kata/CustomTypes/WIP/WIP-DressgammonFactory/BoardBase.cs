using System;
using System.Collections.Generic;
using System.Text;

namespace Kata.CustomTypes.DressgammonFactory
{
    public abstract class BoardBase : Dictionary<PiecePosition<int, int>, PieceBase>, IGameBoard
    {
        protected int Width = 8;
        protected int Length = 8;
        protected Dictionary<PieceColour, PieceSetBase> Pieces { get; set; }
        protected PieceColour WhoseMove { get; set; }

        public BoardBase(int width = 0, int length = 0)
        {
            Pieces = new Dictionary<PieceColour, PieceSetBase>();
            this.Width = width == 0 ? Width : width;
            this.Length = length == 0 ? Length : length;
        }
        public virtual void Initialise(List<PieceSetBase> pieces = default)
        {
            for (var h = 1; h <= Width; h++)
                for (var v = 1; v <= Length; v++)
                    TryAdd(new PiecePosition(h, v), null);
        }
        public abstract void Reset();
        public void Play()
        {
            throw new NotImplementedException();
        }
    }
}
