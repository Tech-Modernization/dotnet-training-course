using System;
using System.Collections.Generic;
using System.Text;

namespace Kata.CustomTypes.FestivalFactoryDone
{
    public class PerformanceSpace
    {
        public PerformanceSpace(BookingScheduleBounds bookingScheduleBounds, int capacity, int maxPerformers, int punterExitRate)
        {
            this.ScheduleBounds = bookingScheduleBounds;
            Capacity = capacity;
            MaxPerformersPerAct = maxPerformers;
            PunterExitRate = punterExitRate;
            Slots = new List<PerformanceSlot>();
        }

        public struct BookingScheduleBounds
        {
            public DateTime FirstSlot;
            public DateTime ClosingTime;
            public TimeSpan ChangeOverTime;
        }

        public BookingScheduleBounds ScheduleBounds { get; }
        public int Capacity { get; }
        public int MaxPerformersPerAct { get; }
        public int PunterExitRate { get; }
        public List<PerformanceSlot> Slots { get; }
    }
}
