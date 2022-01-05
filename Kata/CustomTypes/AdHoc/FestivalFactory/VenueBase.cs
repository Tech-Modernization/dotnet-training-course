using System;
using System.Collections.Generic;
using System.Text;

namespace Kata.CustomTypes.FestivalFactoryDone
{
    public abstract class VenueBase : IVenueManager
    {
        public static readonly TimeSpan SetLength = new TimeSpan(0, 45, 0);
        protected VenueBase(string name)
        {
            Acts = new List<ActBase>();
            Spaces = new List<PerformanceSpace>();
            Name = name;
        }

        protected List<ActBase> Acts { get; }

        protected List<PerformanceSlot> Slots { get; }
        protected List<PerformanceSpace> Spaces { get; }
        protected string Name { get; }

        public PerformanceSpace AddPerformanceSpace(string name, int capacity, int maxPerformers, int punterExitRatePerMin)
        {
            throw new NotImplementedException();
        }

        public ActBase AllocateSlot(ActBase act, PerformanceSpace space)
        {
            // get reputation
            // find slot with max reputation
            // compare to rep and preferred slot
            return default;
        }

        public PerformanceSlot AllocateSlot(ActBase act, PerformanceSpace space, ref ActBase displacedAct)
        {
            throw new NotImplementedException();
        }

        public SortedList<TimeSpan, T> CreateSchedule<T>(PerformanceSpace space)
        {
            throw new NotImplementedException();
        }

        public abstract void CreateSpaces();

        public PerformanceSpace GetSpaceByAct(ActBase act)
        {
            throw new NotImplementedException();
        }
    }
}
