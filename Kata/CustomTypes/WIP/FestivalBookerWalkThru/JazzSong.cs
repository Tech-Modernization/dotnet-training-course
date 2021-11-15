using System;
using System.Collections.Generic;
using System.Text;

namespace Kata.CustomTypes.FestivalBookerWalkThru
{
    public class JazzSong : SongBase
    {
        public JazzSong()
        {
            Genre = MusicGenre.Jazz;
            AverageDuration = new TimeSpan(0, 9, 0);
        }
    }
}
