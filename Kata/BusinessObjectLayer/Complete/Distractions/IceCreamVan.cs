using System;
using System.Collections.Generic;
using System.Text;

namespace Kata.CustomTypes.Demo.Distractions
{
    public class IceCreamVan : DistractionBase
    {
        TimeSpan from = new TimeSpan(14, 0, 0);
        TimeSpan to = new TimeSpan(16, 0, 0);
        protected override Distraction Distraction => Distraction.IceCreamVan;
        protected override TimeSpan PeriodFrom => from;
        protected override TimeSpan PeriodTo => to;
    }
}
