using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Kata.CustomTypes.DressgammonFactory
{
    public abstract class BoardBase : Dictionary<PiecePosition<int, int>, PieceBase>, IGameBoard
    {
        private int width;
        public int Width => width;
        private int length;
        public int Length => length;
        protected Dictionary<PieceColour, PieceSetBase> Pieces { get; set; }
        protected PieceColour WhoseMove { get; set; }

        public PieceBase this[int x, int y]
        {
            get
            {
                var key = this.Keys.SingleOrDefault(k => k.AxisX == x && k.AxisY == y);
                if (key == null)
                    return null;

                return this.ElementAt(Keys.ToList().IndexOf(key)).Value;

            }
        }
        public BoardBase(int width = 0, int length = 0)
        {
            Pieces = new Dictionary<PieceColour, PieceSetBase>();
            this.width = width == 0 ? 8 : width;
            this.length = length == 0 ? 8 : length;
            this.Initialise();
        }
        public virtual void Initialise()
        {
            for (var h = 1; h <= Width; h++)
                for (var v = 1; v <= Length; v++)
                    TryAdd(new PiecePosition(h, v), null);
        }
        public virtual void Initialise(List<PieceSetBase> pieces)
        {
            this.Initialise();
            foreach (var p in pieces)
            {
                Pieces.TryAdd(p[0].Colour, p);
            }
            WhoseMove = PieceColour.White;
        }
        public abstract void Reset();
        public void Play()
        {
            throw new NotImplementedException();
        }
    }
}
