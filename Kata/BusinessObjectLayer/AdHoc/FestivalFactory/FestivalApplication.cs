using System;
using System.Collections.Generic;
using System.Text;

namespace Kata.CustomTypes.FestivalFactoryDone
{
    public class FestivalApplication : IApplicationManager
    {
        public ActBase Act { get; set; }
        public string PreferredVenue { get; set; }
        public TimeSlot PreferredSlot { get; set; }

        public bool OkayWithStandby { get; set; }


    }
}
