using System;
using System.Collections.Generic;
using System.Text;

namespace Kata.CustomTypes.FestivalFactory
{
    public class PerformanceSlot
    {
        public DateTime StartTime { get; }
        public ActBase Act { get; }
        public PerformanceSlot(DateTime startTime)
        {
            StartTime = startTime;
        }
    }
}
