using System;
using System.Collections.Generic;
using System.Text;

namespace Kata.CustomTypes.FestivalFactoryDone
{
    public class PerformanceSlot
    {
        public DateTime StartTime { get; }
        public ActBase Act { get; }

        public readonly TimeSpan SetLength = new TimeSpan(0, 45, 0);
        public PerformanceSlot(DateTime startTime, ActBase act)
        {
            StartTime = startTime;
            Act = act;
        }

     
    }
}
