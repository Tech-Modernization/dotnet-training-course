using System;
using System.Collections.Generic;
using System.Text;

namespace Kata.CustomTypes.Kata.OfficeDistractions
{
    public abstract class DistractionBase : IDistractor
    {
        protected abstract TimeSpan PeriodFrom { get; }
        protected abstract TimeSpan PeriodTo { get; }
        protected abstract Distraction Reason { get; }
        public DistractionResult Distract(int taskId, TimeSpan timeOfDay)
        {
            var result = new DistractionResult();
            var rand = new Random();

            var gotDistracted = timeOfDay >= PeriodFrom && timeOfDay <= PeriodTo;

            var mins = rand.Next(0, 14);
            var secs = rand.Next(1, 59);
            var delay = gotDistracted ? new TimeSpan(0, mins, secs) : new TimeSpan(0, 0, 0);

            result.Delay = delay;
            result.TaskId = taskId;
            result.Reason = gotDistracted ? Reason : Distraction.None;

            return result;
        }
    }
}
