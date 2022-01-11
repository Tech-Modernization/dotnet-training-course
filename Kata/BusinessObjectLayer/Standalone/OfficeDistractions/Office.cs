using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjectLayer.OfficeDistractions
{ 
    public class Office
    {
        private IDistractor[] distractors;

        public Office(params IDistractor[] distractions)
        {
            this.distractors = distractions;
        }

        public void BusinessAsUsual()
        {
            var rand = new Random();

            var distractionTasks = new List<int>();
            for (var i = 0; i < 7; i++)
            {
                distractionTasks.Add(rand.Next(1, 17));
            }

            var nineAm = new TimeSpan(9, 0, 0);
            var taskDuration = new TimeSpan(0, 30, 0);
            var dayTime = nineAm;
            var cob = new TimeSpan(17, 30, 0);
            var currentTask = 1;
            while (dayTime < cob)
            {
                var distractionDuration = new TimeSpan(0, 0, 0);
                if (distractionTasks.Any(i => i == currentTask))
                {
                    distractionDuration = GetDistracted(currentTask, dayTime);
                }

                dayTime += taskDuration + distractionDuration;
                Console.WriteLine($"{dayTime} - Completed task {currentTask++}");
            }
        }

        private TimeSpan GetDistracted(int currentTask, TimeSpan dayTime)
        {
            var rand = new Random();
            var distractor = distractors[rand.Next(0, distractors.Length)];
            var result = distractor.Distract(currentTask, dayTime);

            if (result.Reason == Distraction.None)
            {
                Console.WriteLine($"Oh! Worried for nothing - I thought it was time for the {distractor.GetType().Name}!");
            }
            else
            {
                Console.WriteLine(result);
            }

            return result.Delay;
        }
    }
}
