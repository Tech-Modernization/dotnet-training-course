using System;
using System.Collections.Generic;
using System.Text;

namespace Kata.CustomTypes.Gamependium
{
    public interface IGamePlayService
    {
        GameResultBase Play(Player playerOne, Player playerTwo);
    }
}
