using System;
using System.Collections.Generic;
using System.Text;

namespace Kata.CustomTypes.Gamependium
{
    public interface ITakeable
    {
        TakeResult TakePiece(bool overridePrevention = false);
        TakeResult TakePrevented();
    }
}
