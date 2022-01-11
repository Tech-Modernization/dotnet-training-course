using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessObjectLayer.FestivalFactory
{
    public class Repertoire<T> : Dictionary<T, bool> where T: SongBase
    {
    }
}
