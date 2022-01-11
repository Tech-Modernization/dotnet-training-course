using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessObjectLayer.FestivalFactory
{
    public class FolkSong : SongBase
    {
        public FolkSong() : base(new TimeSpan(0,5,0))
        {
        }
    }
}
