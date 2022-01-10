using System;
using System.Collections.Generic;
using System.Text;

namespace Kata.CustomTypes.Kata.OfficeDistractions
{
    public class FaultyFireAlarm : DistractionBase
    {
        private TimeSpan from = new TimeSpan(9, 0, 0);
        private TimeSpan to = new TimeSpan(17, 30, 0);


        protected override TimeSpan PeriodFrom => from;
        protected override TimeSpan PeriodTo => to;

        protected override Distraction Reason => Distraction.FaultyFireAlarm;
    }
}
