using System;
using System.Collections.Generic;
using System.Text;

using Kata.CustomTypes.FestivalFactory;

namespace Kata.Demos
{
    public class FestivalDemo : DemoBase
    {
        public void Run()
        {
            //var festival = new ClasstonburyFestival();

            var slotLength = new TimeSpan(0, 45, 0);
            var starttime = new DateTime(2021, 10, 30, 12, 30, 00);
            var changeOver = new TimeSpan(0, 30, 0);

            var bands = new List<string> { "ozric tentacles", "gong", "yes", "genesis", "van der graaf generator", "hawkwind", "led zeppelin", "jimi hendrix" };
            bands.Sort();
            foreach(var b in bands)
            {
                Console.WriteLine($"{starttime:t}-{starttime+slotLength:t}:    {b}");
                starttime += slotLength + changeOver;
            }
        }
    }
}
