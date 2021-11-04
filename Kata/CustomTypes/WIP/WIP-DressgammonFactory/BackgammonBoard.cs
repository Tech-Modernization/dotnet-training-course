using System;
using System.Collections.Generic;
using System.Text;

namespace Kata.CustomTypes.DressgammonFactory
{
    public class BackgammonBoard : BoardBase, IGameBoard
    {
        public BackgammonBoard() : base(24, 5)
        {
        }

        public override void Reset()
        {
            throw new NotImplementedException();
        }
    }
}
