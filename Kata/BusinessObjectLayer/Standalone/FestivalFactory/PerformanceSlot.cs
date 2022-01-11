using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessObjectLayer.FestivalFactory
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
