using System;
using System.Collections.Generic;
using System.Linq;

using Kata.CustomTypes.FestivalBookerWalkThru;

using Newtonsoft.Json;

namespace Kata.Demos
{
    public class FestivalBookerWalkThruDemo : DemoBase
    {
        List<Venue> venuesV1;
        List<VenueBase> venuesV2;
        public override void Run()
        {
            AddPart(RunSection2, "Create a performance schedule");
            AddPart(RunSection3, "Initialise and traverse the object hierarchy");
            AddPart(RunSection4, "Convert old Venue list into new hierarchy");
            AddPart(RunQuestion4p2, "Demo base methods");
            base.Run();
        }

        public void RunQuestion4p2()
        {
            var thing = new ConcreteThing();
            thing.Run();
        }

        public void RunSection4()
        {
            var jsonVenues = JsonConvert.SerializeObject(venuesV1);
            //venuesV2 = JsonConvert.DeserializeObject<List<VenueBase>>(jsonVenues);
            venuesV2 = new List<VenueBase>
            {
                new JazzVenue()
                {
                    Name = "The Blue Note",
                    Acts = new List<Act>()
                    {
                        new Act(){Name = "Wynton Marsalis"},
                        new Act(){Name = "Miles Davies"},
                        new Act(){Name = "Dave Brubeck"}
                    },
                    Spaces = new List<PerformanceSpace>()
                    {
                        new PerformanceSpace()
                        {
                            Name = "The Big Room",
                            Schedule = new List<PerformanceSlot>()
                        }
                    }
                }
            };

            foreach (var v in venuesV2)
            {
                dbg($"Venue: {v.Name}");
                foreach (var s in v.Spaces)
                {
                    dbg($"    Space: {s.Name}");
                    if (s.Schedule.Count == 0)
                    {
                        dbg("Schedule to be announced but the following acts are rumoured to appear:\n        ");
                        dbg(string.Join("\n        ", v.Acts.Select(a => a.Name).ToList()));
                    }
                    else
                        foreach (var slot in s.Schedule)
                        {
                            dbg($"        Start: {slot.StartTime}, Act: {slot.Act.Name}");
                        }
                }
            }

        }
        public void RunSection3()
        {
            venuesV1 = new List<Venue>
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

            foreach (var v in venuesV1)
            {
                dbg($"Venue: {v.Name}");
                foreach (var s in v.Spaces)
                {
                    dbg($"    Space: {s.Name}");
                    if (s.Schedule.Count == 0)
                    {
                        dbg("Schedule to be announced but the following acts are rumoured to appear:\n        ");
                        dbg(string.Join("\n        ", v.Acts.Select(a => a.Name).ToList()));
                    }
                    else foreach (var slot in s.Schedule)
                    {
                        dbg($"        Start: {slot.StartTime}, Act: {slot.Act.Name}");
                    }
                }
            }
        }

        public abstract class AbstractThing
        {
            public abstract void DoSomething();
            public virtual void SaySomething(string message)
            {
                Console.WriteLine(message);
            }
            public void SaySomethingFixed(string message)
            {
                Console.WriteLine("fixed: " + message);
            }

        }
        public class ConcreteThing : AbstractThing
        {
            public void Run()
            {
                SaySomething("this calls the override");
                SaySomethingFixed("this calls the base method");

            }
            public override void DoSomething()
            {
                Console.WriteLine("Doing summat");
            }

            public override void SaySomething(string message)
            {
                // this calls the original version of the method
                base.SaySomething(message);

                // but our version can either not bother or build on it
                Console.WriteLine("I called the base method");
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
                dbg(v.Name);

            foreach (var a in acts)
                dbg(a.Name);

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