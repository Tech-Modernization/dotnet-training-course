using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessObjectLayer.FestivalFactory
{
    public interface IRepertoireBuilder
    {
        SongBase AddSong<T>(ActBase act) where T : new();
    }
}
