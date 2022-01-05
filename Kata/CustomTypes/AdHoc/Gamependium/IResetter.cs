using System;
using System.Collections.Generic;
using System.Text;

namespace Kata.CustomTypes.Gamependium
{
    public interface IResetter
    {
        void Reset();
        void Initialise(List<PieceSetBase> pieces);
    }
}
