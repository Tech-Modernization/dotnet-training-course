using System;
using System.Collections.Generic;
using System.Text;

namespace Kata.CustomTypes.FestivalFactoryDone
{
    public abstract class SongBase
    {
        public TimeSpan AverageDuration { get; }

        protected SongBase(int averageDuration)
        {
            AverageDuration = new TimeSpan(0, averageDuration, 0);
        }
    }
}
