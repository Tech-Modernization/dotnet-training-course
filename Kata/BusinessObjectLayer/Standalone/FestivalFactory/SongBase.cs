using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessObjectLayer.FestivalFactory
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
