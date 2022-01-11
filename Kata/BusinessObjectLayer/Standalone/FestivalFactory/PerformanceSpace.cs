using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessObjectLayer.FestivalFactory
{
    public class PerformanceSpace
    {
        public string Name { get; }
        public int Capacity { get; }
        public int MaxPerformers { get; }
        public int PunterExitRatePerMinute { get; }
        public List<PerformanceSlot> Schedule { get; }

        public PerformanceSpace(string name, int capacity, int maxPerformers, int punterExitRatePerMinute)
        {
            Name = name;
            Capacity = capacity;
            MaxPerformers = maxPerformers;
            PunterExitRatePerMinute = punterExitRatePerMinute;
            Schedule = new List<PerformanceSlot>();
        }


    }
}
