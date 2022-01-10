using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Kata.CustomTypes.FestivalFactoryDone
{
    public interface IVenueManager
    {
        PerformanceSpace AddPerformanceSpace(string name, int capacity, int maxPerformers, int punterExitRatePerMin);
        PerformanceSpace GetSpaceByAct(ActBase act);
        SortedList<TimeSpan, T> CreateSchedule<T>(PerformanceSpace space);
        PerformanceSlot AllocateSlot(ActBase act, PerformanceSpace space, ref ActBase displacedAct);
    }
}