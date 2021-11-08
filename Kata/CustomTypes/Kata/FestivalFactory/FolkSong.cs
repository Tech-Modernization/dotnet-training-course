using System;
using System.Collections.Generic;
using System.Text;

namespace Kata.CustomTypes.FestivalFactory
{
    public class FolkSong : SongBase
    {
        public FolkSong() : base(new TimeSpan(0,5,0))
        {
        }
    }
}
