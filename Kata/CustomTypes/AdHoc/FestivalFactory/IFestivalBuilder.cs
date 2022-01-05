using System;
using System.Collections.Generic;

namespace Kata.CustomTypes.FestivalFactoryDone
{
    public interface IFestivalBuilder
    {
        T AddVenue<T>(string name);
    }
}