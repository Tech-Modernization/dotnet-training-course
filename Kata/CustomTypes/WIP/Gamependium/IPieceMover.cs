using System;
using System.Collections.Generic;
using System.Text;

namespace Kata.CustomTypes.Gamependium
{
    public interface IPieceMover
    {
        MoveResultBase Move(BoardBase board, PieceBase piece, PieceMove direction, int spaces);
    }
}
