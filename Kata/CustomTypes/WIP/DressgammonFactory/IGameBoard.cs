using System;
using System.Collections.Generic;
using System.Text;

namespace Kata.CustomTypes.DressgammonFactory
{
    public interface IGameBoard
    {
        void Reset();
        void Play();
        void Initialise(List<PieceSetBase> pieces);
    }
}
