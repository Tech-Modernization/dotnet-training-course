using System;
using System.Collections.Generic;
using System.Text;

namespace Kata.CustomTypes.FestivalFactoryDone
{
    public class Repertoire<T> : Dictionary<T, bool> where T: SongBase
    {
    }
}
