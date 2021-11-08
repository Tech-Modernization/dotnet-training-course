using System;
using System.Collections.Generic;
using System.Text;

using Kata.CustomTypes.FestivalFactory;

namespace Kata.Demos
{
    public class FestivalDemo : DemoBase
    {
        public override void Run()
        {
            var blueNote = new JazzVenue("The Blue Note");
            var ronnies = new JazzVenue("Ronnie Scott's");

            var bigRoom = blueNote.AddPerformanceSpace("the Big room", 300, 10, 15);
            var hogeys = blueNote.AddPerformanceSpace("Hogey's Hideaway", 100, 3, 10);
            var lounge = ronnies.AddPerformanceSpace("Ronnie's Lounge", 400, 12, 20);
            var upstairs = ronnies.AddPerformanceSpace("Upstairs", 150, 6, 10);

            var changeOver = new TimeSpan(0, 30, 0);
            var setLength = new TimeSpan(0, 45, 0);

            var bigRoomSched = blueNote.CreateSchedule(bigRoom, DateTime.Parse("29/10/2021 12:30"), new TimeSpan(23, 30, 0),
                setLength, changeOver);
            var hogeySched = blueNote.CreateSchedule(hogeys, DateTime.Parse("29/10/2021 12:30"), new TimeSpan(23, 00, 0),
                setLength, changeOver);
            var loungeSched = ronnies.CreateSchedule(lounge, DateTime.Parse("29/10/2021 12:30"), new TimeSpan(1, 30, 0),
                setLength, changeOver);
            var upstairsSched = ronnies.CreateSchedule(upstairs, DateTime.Parse("29/10/2021 12:30"), new TimeSpan(2, 30, 0),
                setLength, changeOver);

            var venues = new List<VenueBase> { blueNote, ronnies };
            foreach (var v in venues)
            {
                Console.WriteLine($"Venue: {v.Name}");
                foreach (var s in v.Spaces)
                {
                    Console.WriteLine($"    Performance space: {s.Name}");
                    foreach (var slot in s.Schedule)
                    {
                        Console.WriteLine($"        {slot.StartTime:g}: {(slot.Act == null ? "TBA" : slot.Act.Name)}");

                    }
                }
            }
        }

    }
}
