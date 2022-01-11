using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessObjectLayer.FestivalFactory
{
    public class FestivalApplication
    {
        public ActBase Act { get; set; }

        public List<int> PreferredDays { get; set; }
        public List<TimeSlot> PreferredSlots { get; set; }
        public string PreferredVenueName { get; set; }
        public string PreferredPerformanceSpace { get; set; }

        public bool StandbyWilling { get; set; }
    }
}
