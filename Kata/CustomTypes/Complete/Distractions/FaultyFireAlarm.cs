using System;
using System.Collections.Generic;
using System.Text;

namespace Kata.CustomTypes.Demo.Distractions
{
    public class FaultyFireAlarm : DistractionBase
    {
        TimeSpan from = new TimeSpan(8, 0, 0);
        TimeSpan to = new TimeSpan(18, 0, 0);
        protected override Distraction Distraction { get; }
        protected override TimeSpan PeriodFrom => from;
        protected override TimeSpan PeriodTo => to;
    }
}
