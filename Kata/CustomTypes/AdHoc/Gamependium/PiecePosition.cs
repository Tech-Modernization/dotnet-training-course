using System;
using System.Collections.Generic;
using System.Text;

namespace Kata.CustomTypes.Gamependium
{
    public class PiecePosition : PiecePosition<int, int>
    {
        public PiecePosition(int axisX, int axisY) : base(axisX, axisY)
        {
        }
    }
    public class PiecePosition<TAxisX, TAxisY>
    {
        public TAxisX AxisX;
        public TAxisY AxisY;

        public PiecePosition(TAxisX axisX, TAxisY axisY)
        {
            AxisX = axisX;
            AxisY = axisY;
        }

        public override int GetHashCode()
        {
            return Convert.ToInt32(AxisX) * 1000 + Convert.ToInt32(AxisY) * 10;
        }

        public override bool Equals(object obj)
        {
            var pp = obj as PiecePosition<TAxisX, TAxisY>;
            if (pp == null) return false;
            return pp.AxisX.Equals(AxisX) && pp.AxisY.Equals(AxisY);
        }
    }
}
