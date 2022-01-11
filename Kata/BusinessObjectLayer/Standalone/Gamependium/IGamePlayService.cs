using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessObjectLayer.Gamependium
{
    public interface IGamePlayService
    {
        GameResultBase Play(Player playerOne, Player playerTwo);
    }
}
