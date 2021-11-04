using System;
using System.Collections.Generic;
using System.Text;

namespace Kata.Demos
{
    public class DateTimeDemo : IDemo
    {
        public void Run()
        {
            var dt = new DateTime(1969, 2, 8, 22, 32, 0);
            var myBirthday = dt.ToLongDateString();
            myBirthday = dt.ToShortDateString();
            myBirthday = $"{dt:MMM dd, y}";

            var exactAge = DateTime.Now.Subtract(dt);
            var msg = $".pd. is {exactAge.Days} days, {exactAge.Hours} hours and {exactAge.Minutes} minutes old";
            var mins = $"so he's been aroun dfor {exactAge.TotalSeconds}";

            var hurdles = new List<int>(); for (var d = 10; d < 110; d += 10)
            {
                hurdles.Add(d);
            }
            Console.WriteLine($"110m Hurdles\nHurdles are placed at: {string.Join("m, ", hurdles)}m");

            var tourTimes = new List<TimeSpan>();
            var tourTime = new TimeSpan(10, 0, 0);
            var turnaroundTime = new TimeSpan(1, 30, 0);
            do
            {
                tourTimes.Add(tourTime);
                tourTime += turnaroundTime;
            }
            while (tourTime.Hours < 17);
            Console.WriteLine($"\n-----\nBus tour timetable:\n    {string.Join("\n    ", tourTimes)}");

            var tourTimesOn = new List<DateTime>();
            for (var m = 1; m < 13; m++)
            {
                var y = DateTime.Now.Year;
                var nextDate = new DateTime(y, m, 1);
                var lastTourHour = m > 4 && m < 9 ? 20 : 17;

                tourTime = new TimeSpan(10, 0, 0);
                tourTimesOn.Clear();

                do
                {
                    tourTimesOn.Add(nextDate + tourTime);
                    tourTime += turnaroundTime;
                }
                while (tourTime.Hours < lastTourHour);
                Console.WriteLine($"\n-----\nBus tour timetable on {nextDate:g}:\n    {string.Join("\n    ", tourTimesOn)}");

            }

            var perfTimesOn = new List<DateTime>();
            var festDays = 4;
            var festDate = DateTime.Parse("27/6/2020");
            turnaroundTime = new TimeSpan(1, 15, 0);
            for (var d = 0; d < festDays; d++)
            {
                var isSunday = festDate.DayOfWeek == DayOfWeek.Sunday;
                var lastBandOn = new TimeSpan(isSunday ? 21 : 23, isSunday ? 15 : 45, 0);

                var slotTime = new TimeSpan(12, 30, 0);
                var nextPerf = festDate + slotTime;
                perfTimesOn.Clear();

                do
                {
                    perfTimesOn.Add(nextPerf);
                    nextPerf += turnaroundTime;
                }
                while (nextPerf.Hour < lastBandOn.Hours);

                Console.WriteLine($"\n-----\nPerformance times on {festDate:d}:\n    {string.Join("\n    ", perfTimesOn)}");
                festDate = festDate.AddDays(1);
            }

        }
    }
}
