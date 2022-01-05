using System;
using System.Collections.Generic;
using System.Text;

namespace Kata.CustomTypes.Demo.Distractions
{
    public class DistractionResult
    {
        public int TaskId;
        public TimeSpan Delay;
        public Distraction Reason;

        public override string ToString()
        {
            return $"*** Drat! *** Distracted from task #{TaskId} by {Reason} for {Delay.Minutes}m {Delay.Seconds}s";
        }
    }
}
