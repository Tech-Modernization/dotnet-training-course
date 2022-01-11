using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessObjectLayer.OfficeDistractions
{
    public class DistractionResult
    {
        public int TaskId;
        public TimeSpan Delay;
        public Distraction Reason;

        public override string ToString()
        {
            return $"*** DRAT *** got distracted from task #{TaskId} by {Reason} for {Delay.Minutes}m {Delay.Seconds}s";
        }
    }
}
