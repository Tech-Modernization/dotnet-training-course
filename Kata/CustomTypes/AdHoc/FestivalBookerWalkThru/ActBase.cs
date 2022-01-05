using System;
using System.Collections.Generic;
using System.Text;

namespace Kata.CustomTypes.FestivalBookerWalkThru
{
    public abstract class ActBase
    {
        public string Name;
        public MusicGenre Genre;
        public List<SongBase> Repertoire;
    }
}
