using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Kata.CustomTypes.WIP.FestivalBookerWalkThru;

namespace Kata.Demos
{
    public class FestivalBookerWalkThruDemo : DemoBase
    {
        public override void Run()
        { 
        }
        public void RunSection3()
        {
            var venues = new List<Venue>
            {
                new Venue() 
                {
                    Name = "60s Dino club",
                    Acts = new List<Act>()
                    {
                        new Act(){Name = "The Troggs"},
                        new Act(){Name = "The Faces"},
                        new Act(){Name = "Herman's Hermits"}
                    },
                    Spaces = new List<PerformanceSpace>()
                    {
                        new PerformanceSpace()
                        {
                            Name = "room 1",
                            Schedule = new List<PerformanceSlot>()
                        }
                    } 
                },
                new Venue()
                {
                    Name = "Metallurgy",
                    Acts = new List<Act>()
                    {
                        new Act() {Name = "Metallica"},
                        new Act() {Name = "Megadeth"},
                        new Act() {Name = "Sepultura"}
                    },

                    Spaces = new List<PerformanceSpace>()
                    {
                        new PerformanceSpace()
                        {
                            Name = "Death room",
                            Schedule = new List<PerformanceSlot>()
                        },
                        new PerformanceSpace()
                        {
                            Name = "Thrash",
                            Schedule = new List<PerformanceSlot>()
                        }
                    }
                },
                new Venue()
                {
                    Name = "Punktilious",
                    Acts = new List<Act>()
                    {
                        new Act() {Name = "The Johns"},
                        new Act() {Name = "The Exploited"},
                        new Act() {Name = "The Skids"}
                    },
                    Spaces = new List<PerformanceSpace>()
                    {
                        new PerformanceSpace()
                        {
                            Name = "Rainbow room",
                            Schedule = new List<PerformanceSlot>()
                        }
                    }
                },
            };

            foreach (var v in venues)
            {
                cw($"Venue: {v.Name}");
                foreach (var s in v.Spaces)
                {
                    cw($"    Space: {s.Name}");
                    if (s.Schedule.Count == 0)
                    {
                        cw("Schedule to be announced but the following acts are rumoured to appear:\n        ");
                        cw(string.Join("\n        ", v.Acts.Select(a => a.Name).ToList()));
                    }
                    else foreach (var slot in s.Schedule)
                    {
                        cw($"        Start: {slot.StartTime}, Act: {slot.Act.Name}");
                    }
                }
            }
        }

        public abstract class AbstractThing
        {
            public abstract void DoSomething();
        }
        public class ConcreteThing : AbstractThing
        {
            public override void DoSomething()
            {
                Console.WriteLine("Doing summat");
            }
        }


        public void RunSection2()
        {
            var venues = new List<Venue>
            {
                new Venue(){Name = "Biff's"},
                new Venue(){Name = "The Jazz Cafe"},
                new Venue(){Name = "The Queen's Head"},
            };

            var newVenue = new Venue() { Name = "the Adam & Eve" };

            var acts = new List<Act>
            {
                new Act(){Name = "The Sleeping Arrangements"},
                new Act(){Name = "Buck's Fizz"},
                new Act(){Name = "Gun"},
                new Act(){Name = "Hue & Cry"},
                new Act(){Name = "Arctic Monkeys"},
                new Act(){Name = "The Macc Lads"},
            };

            var perfSlots = new List<PerformanceSlot>();

            foreach (var v in venues)
                cw(v.Name);

            foreach (var a in acts)
                cw(a.Name);

            var showsFromTime = new TimeSpan(12, 30, 00);
            var festivalStartDate = new DateTime(2021, 10, 29);
            var firstSlot = new DateTime(2021, 10, 29, 12, 30, 0);
            var festLength = 3;

            var dateFromText = DateTime.Parse("29/10/2021");

            // we need a fixed relative time to keep adding
            var oneHourTimeSlot = new TimeSpan(1, 0, 0);

            // we need a copy of the start date and time to add to
            var nextSlot = festivalStartDate + showsFromTime;

            foreach (var a in acts)
            {
                // for each act, create a new time slot, 1 hour later than the last one
                perfSlots.Add(new PerformanceSlot()
                {
                    StartTime = nextSlot,
                    Act = a
                });

                nextSlot += oneHourTimeSlot;
            }

            foreach (var slot in perfSlots)
            {
                Console.WriteLine($"{slot.StartTime:g} Act: {slot.Act.Name}");
            }

        }

    }
}