using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace BusinessObjectLayer.FestivalFactory
{
    public abstract class VenueBase : IVenueManager
    {
        public string Name { get; }
        protected List<ActBase> Acts { get; }
        public List<PerformanceSpace> Spaces { get; }
        public VenueBase(string name)
        {
            Name = name;
            Acts = new List<ActBase>();
            Spaces = new List<PerformanceSpace>();
        }

        public PerformanceSpace AddPerformanceSpace(string name, int capacity, int maxPerformers, int punterExitRatePerMin)
        {
            var newSpace = new PerformanceSpace(name, capacity, maxPerformers, punterExitRatePerMin);
            Spaces.Add(newSpace);
            return newSpace;
        }

        public List<PerformanceSlot> CreateSchedule(PerformanceSpace space, DateTime firstSlotTime,
            TimeSpan venueClosingTime, TimeSpan setLength, TimeSpan changeOver)
        {
            var totalTimeLapseBetweenPerfs = setLength + changeOver;
            var interimSlotTime = firstSlotTime;
            // to put an act on, the start time must be within "timelapse" of closing time to be able to get everyone out etc.
            // it's not enough to have the proposed starttime just be before closing time, it has to be "timelapse" before...

            while(venueClosingTime - interimSlotTime.TimeOfDay >= totalTimeLapseBetweenPerfs)
            {
                space.Schedule.Add(new PerformanceSlot(interimSlotTime));
                interimSlotTime += totalTimeLapseBetweenPerfs;
            }
            return space.Schedule;
        }

        public List<PerformanceSpace> GetSpacesByAct(ActBase act)
        {
            /*
            var appropSpaces = new List<PerformanceSpace>();
            foreach(var s in Spaces)
            { 
                if (s.MaxPerformers >= act.NumPerformers)
                {
                    appropSpaces.Add(s);
                }
            }

            code below is functionally identical to code above :=)
            */
            return Spaces.Where(s => s.MaxPerformers >= act.NumPerformers).ToList();
        }

        public ActBase AllocateSlot(ActBase act, PerformanceSpace space)
        {
            // picking the right slot for the act's profile.
            throw new NotImplementedException();
        }
    }
}
