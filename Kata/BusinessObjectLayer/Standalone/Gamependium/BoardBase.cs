using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace BusinessObjectLayer.Gamependium
{
    public abstract class BoardBase : Dictionary<PiecePosition<int, int>, PieceBase>, IResetter
    {
        public int Width { get; }
        public int Length { get; }
        protected Dictionary<PieceColour, PieceSetBase> Pieces { get; set; }
        protected PieceColour WhoseMove { get; set; }
        public T Concrete<T>() where T : BoardBase => this as T;
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
        public BoardBase(int width = 8, int length = 8)
        {
            Pieces = new Dictionary<PieceColour, PieceSetBase>();
            Width = width;
            Length = length;
            Initialise();
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
    }
}
