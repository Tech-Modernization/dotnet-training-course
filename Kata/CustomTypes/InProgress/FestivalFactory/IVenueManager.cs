using System;
using System.Collections.Generic;
using System.Text;

namespace Kata.CustomTypes.FestivalFactory
{
    public interface IVenueManager
    {
        PerformanceSpace AddPerformanceSpace(string name, int capacity, int maxPerformers, int punterExitRatePerMin);
        List<PerformanceSlot> CreateSchedule(PerformanceSpace space, DateTime firstSlotTime, TimeSpan venueClosingTime, TimeSpan setLength, TimeSpan changeOver);
        List<PerformanceSpace> GetSpacesByAct(ActBase act);
        ActBase AllocateSlot(ActBase act, PerformanceSpace space);

    }
}
