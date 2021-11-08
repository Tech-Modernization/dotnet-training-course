using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

using Kata.CustomTypes.Extensions;

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
            var fillData = new List<Tuple<int, int, PieceColour>>
            {
                new Tuple<int, int, PieceColour>(1,2,PieceColour.White),
                new Tuple<int, int, PieceColour>(6,5,PieceColour.Black),
                new Tuple<int, int, PieceColour>(8,3,PieceColour.Black),
                new Tuple<int, int, PieceColour>(12,5,PieceColour.White)
            };

            var whiteIndex = 0;
            var blackIndex = 0;

            foreach (var k in Keys.ToList())
                this[k] = null;

            foreach(var tup in fillData)
            {
                var row = tup.Item1;
                var qty = tup.Item2;
                var col = tup.Item3;

                for (var i = col == PieceColour.White ? whiteIndex : blackIndex; i < qty; i++)
                {
                    this[new PiecePosition(row, i + 1)] = Pieces[col][i];
                }

                // work out the row number in down column

                row = 24 - (row - 1);
                col = col == PieceColour.White ? PieceColour.Black : PieceColour.White;
                for (var i = col == PieceColour.White ? blackIndex : whiteIndex; i < qty; i++)
                {
                    this[new PiecePosition(row, i + 1)] = Pieces[col][i];
                }
            }
        }

        public override string ToString()
        {
        /* 
        
            Make this...but with any positions held...

        +-----------------------------+
        | W W W W W         B B B B B |
        | > > > > >         < < < < < |
        | > > > > >         < < < < < |
        | > > > > >         < < < < < |
        | B B B > >         < < W W W |
        | > > > > >         < < < < < |
        +-----------------------------+
        |                             |
        +-----------------------------+
        | B B B B B         W W W W W |
        | > > > > >         < < < < < |
        | > > > > >         < < < < < |
        | > > > > >         < < < < < |
        | > > > > >         < < < < < |
        | W W > > >         < < < B B |
        +-----------------------------+

        */

            var sb = new StringBuilder();
            var divider = $"+{new string('-', 29)}+";
            var rail = $"|{new string(' ', 29)}|";

            var railPos = rail.Length / 2;
            foreach(var railPiece in Rail)
            {
                var colour = railPiece.Colour == PieceColour.White ? "W" : "B";
                rail.Overwrite(railPos, colour);

            }
            sb.AppendLine(divider);
            for(var up = 12; up > 0; up--)
            {
                // insert the rail halfway down...
                if (up == 6)
                {
                    sb.AppendLine(string.Format("{0}\n{1}\n{0}", divider, rail));
                }

                // reset the point line, cuz if anything's on this row, it gets changed
                var point = $"|{" >".Repeat(5)}{" ".Repeat(9)}{"< ".Repeat(5)}|";

                // have to consider the up column and the down column
                // in the layout. 
                var down = 24 - (up - 1);

                // if there's nothing either side, leave the point line alone and move on
                var occupied = this.Where(kvp => kvp.Key.AxisX == up || kvp.Key.AxisX == down)
                                   .Where(kvp => this[kvp.Key] != null)
                                   .Select(kvp => kvp.Key)
                                   .ToList();

                if (occupied.Count == 0)
                {
                    sb.AppendLine(point);
                    continue;
                }

                foreach (var pos in occupied)
                {
                    // if we got positions back, go thru and work out what char positions to update
                    var upCharPos = 2 + (pos.AxisY - 1) * 2;
                    var downCharPos = point.Length - (upCharPos + 1);
                    var colour = this[pos].Colour == PieceColour.White ? "W" : "B";
                    point = point.Overwrite(pos.AxisX > 12 ? downCharPos : upCharPos, colour);
                }
                sb.AppendLine(point);
            }
                
            sb.AppendLine(divider);

            return sb.ToString();
        }
    }
}
