using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessObjectLayer.Gamependium
{
    public interface ITakeable
    {
        TakeResult TakePiece(bool overridePrevention = false);
        TakeResult TakePrevented();
    }
}
