using System;
using System.Collections.Generic;
using System.Text;

namespace Kata.CustomTypes.FestivalFactory
{
    public class JazzSong : SongBase
    {
        public JazzSong() : base(new TimeSpan(0,9,0))
        {
        }
    }
}
