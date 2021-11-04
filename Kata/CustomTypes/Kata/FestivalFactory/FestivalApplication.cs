using System;
using System.Collections.Generic;
using System.Text;

namespace Kata.CustomTypes.FestivalFactory
{
    public class FestivalApplication
    {
        public ActBase Act { get; }

        public List<TimeSlot> PreferredSlots { get; }
        public string PreferredVenueName { get; }
        public string PreferredPerformanceSpace { get; }

        public bool StandbyWilling { get; }
    }
}
