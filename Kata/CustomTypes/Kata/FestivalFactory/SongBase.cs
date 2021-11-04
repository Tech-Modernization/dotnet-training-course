using System;
using System.Collections.Generic;
using System.Text;

namespace Kata.CustomTypes.FestivalFactory
{
    public abstract class SongBase
    {
        public TimeSpan AverageDuration { get; }
        public SongBase(TimeSpan averageDuration)
        {
            AverageDuration = averageDuration;
        }
    }
}
