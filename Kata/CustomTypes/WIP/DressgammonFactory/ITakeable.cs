using System;
using System.Collections.Generic;
using System.Text;

namespace Kata.CustomTypes.DressgammonFactory
{
    public interface ITakeable<T>
    {
        TakeResult<T> TakePiece(bool overridePrevention = false);
        TakeResult<T> TakePrevented();
    }
}
