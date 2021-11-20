using System;
using System.Collections.Generic;
using System.Text;

using Kata.CustomTypes.Demo.Distractions;

namespace Kata.CustomTypes.Demo.Distractions
{
    public class SandwichTrolley : DistractionBase
    {
        TimeSpan from = new TimeSpan(10, 30, 0);
        TimeSpan to = new TimeSpan(14, 30, 0);
        protected override Distraction Distraction => Distraction.SandwichTrolley;
        protected override TimeSpan PeriodFrom => from;
        protected override TimeSpan PeriodTo => to;
    }
}
