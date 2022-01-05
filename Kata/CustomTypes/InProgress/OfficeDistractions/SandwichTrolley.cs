using System;
using System.Collections.Generic;
using System.Text;

namespace Kata.CustomTypes.Kata.OfficeDistractions
{
    public class SandwichTrolley : DistractionBase
    {
        private TimeSpan from = new TimeSpan(10, 30, 0);
        private TimeSpan to = new TimeSpan(14, 0, 0);

        protected override TimeSpan PeriodFrom => from;
        protected override TimeSpan PeriodTo => to;

        protected override Distraction Reason => Distraction.SandwichTrolley;
    }
}
