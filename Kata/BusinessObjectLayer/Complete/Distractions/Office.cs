using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjectLayer.Demo.Distractions
{
    public class Office
    {
        private IDistractor[] distractions;
        public Office(params IDistractor[] distractions)
        {
            this.distractions = distractions;
        }
        public void BusinessAsUsual()
        {
            var rand = new Random();
            var slot = new TimeSpan(0, 30, 0);
            var five30pm = new TimeSpan(17, 30, 0);
            var nineAm = new TimeSpan(9, 0, 0);
            var dayTime = nineAm;
            var currentTask = 1;
            var distractionPoints = new List<int>();
            for (var i = 0; i < 5; i++)
                distractionPoints.Add(rand.Next(1, 16));

            while(dayTime < five30pm)
            {
                Console.WriteLine($"{dayTime} - Started task #{currentTask}");
                if (distractionPoints.Any(i => i == currentTask))
                {
                    var distractionResult = Distract(currentTask, dayTime);
                    if (distractionResult != null)
                    {
                        Console.WriteLine(distractionResult);
                    }
                    dayTime += slot + distractionResult?.Delay ?? default(TimeSpan);
                }
                else
                {
                    dayTime += slot;
                }

                Console.WriteLine($"{dayTime} - Completed task #{currentTask++}");
            }
        }

        public DistractionResult Distract(int currentTask, TimeSpan taskStartedAt)
        {
            // if none of the others, go with the fire alarm
            foreach(var distractor in distractions)
            {
                if (distractor is FaultyFireAlarm) continue;
                var result = distractor.Distract(currentTask, taskStartedAt);
                if (result != null)
                    return result;
            }

            var ffa = distractions.SingleOrDefault(d => d is FaultyFireAlarm);
            if (ffa == null)
            {
                Console.WriteLine("Would normally have been distracted by the fire alarm, but it's fixed!  Hurrah!");
            }
            return ffa?.Distract(currentTask, taskStartedAt);
        }
    }
    
}
