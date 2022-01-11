using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessObjectLayer.OfficeDistractions
{
    public class IceCreamVan : DistractionBase
    {
        private TimeSpan from = new TimeSpan(15, 0, 0);
        private TimeSpan to = new TimeSpan(17, 0, 0);
        

        protected override TimeSpan PeriodFrom => from;
        protected override TimeSpan PeriodTo => to;
        protected override Distraction Reason => Distraction.IceCreamVan;
    }
}
