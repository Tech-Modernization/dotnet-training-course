using System;
using System.Collections.Generic;
using System.Text;

namespace Kata.CustomTypes.Demo.Distractions
{
    public abstract class DistractionBase : IDistractor
    {
        protected abstract Distraction Distraction { get; }
        protected abstract TimeSpan PeriodFrom { get; }
        protected abstract TimeSpan PeriodTo { get; }

        public virtual DistractionResult Distract(int currentTask, TimeSpan taskStartTime)
        {
            var gotDistractedByThis = (taskStartTime >= PeriodFrom && taskStartTime <= PeriodTo);
            if (!gotDistractedByThis)
                return null;

            var rand = new Random();
            var mins = rand.Next(0, 14);
            var secs = rand.Next(0, 59);
            var delay = new TimeSpan(0, mins, secs);
            return new DistractionResult() { TaskId = currentTask, Delay = delay, Reason = Distraction };
        }
    }
}
