using System;
using System.Collections.Generic;
using Kata.Demos;
using Kata.Helpers;
using Kata.CustomTypes.MenuFactoryList;
using Kata.CustomTypes.PublicationFactory;
using Kata.CustomTypes.RecyclingFactory;
using Kata.CustomTypes.EntUnitDemo;

namespace Kata
{
    public class Program
    {
        static void Main(string[] args)
        {
            var demo = new DictionaryDemo<string, decimal>();
            Console.WriteLine($"Looking up beer: {demo.Search("beer")}");

            demo.Setup("beer", 3.4M);
            demo.Setup("beer", 3.4M);
            demo.Setup("water", 1.2M);
            demo.Setup("tea", 2.2M);
            demo.Run();

            Console.WriteLine($"Looking up eggs: {demo.Search("eggs")}");
        }


        /*
        static void Main(string[] args)
        {
            IDemo demoInstance = default;
            var demoMenu = MenuHelper<IDemo>.CreateMenu();
            do
            {
                demoInstance = demoMenu.SelectFromMenu("Choose a demo: ");
                demoInstance?.Run();
            }
            while (demoInstance != null);
        }
*/
        /*
        static void Main(string[] args)
        {
            var bins = new ContainerBase[5];
            bins[0] = new GlassContainer();
            bins[1] = new PaperContainer();
            bins[2] = new OrganicContainer();
            bins[3] = new PlasticContainer();
            bins[4] = new TinContainer();

            var wasteItems = new MaterialBase[5] {
                new WineBottle(),
                    new Newspaper(),
                    new OrangePeel(),
                    new WaterBottle(),
                    new BakedBeans()
            };

            foreach(var wi in wasteItems)
            {
                foreach(var b in bins)
                {
                    if (wi.GetType().BaseType.Name.Replace("Base", "") == b.GetType().Name.Replace("Container", ""))
                    {
                        Console.WriteLine($"{wi} goes in {b}");
                        break;
                    }
                }
            }
        }

        
        static void loopDemoContext(RecyclingFactoryDemo demo)
        {
            for (var pm = Placement.Implicit; pm <= Placement.Sample; pm++)
            {
                demo.PlacementMode = pm;
                for (var ig = 0; ig < 2; ig++)
                {
                    demo.IgnoreMiddleTier = (ig & 1) == 0;
                    demo.Run();
                    demo.GenerateWaste();
                }
            }
        }
        */

        //private static void FillZiggyStardust(TrackListBase sender, EventArgs args)
        //{
        //    sender.Add("CD", "Five Years");
        //    sender.Add("CD", "Soul Love");
        //    sender.Add("CD", "Moonage Daydream");
        //    sender.Add("CD", "Star Man");
        //    sender.Add("CD", "Lady Stardust");
        //    sender.Add("CD", "New Guy Something?");
        //    sender.Add("CD", "Suffragette City");
        //    sender.Add("CD", "Rock And Roll Suicide");
        //    sender.Add("CD", "Velvet Goldmine");
        //}

        //private static void FillDarkSideOfTheMoon(TrackListBase sender, EventArgs args)
        //{
        //    var dsotm = new VinylAlbum(1);
        //    var ziggy = new CompactDiscAlbum(1, false);
        //    dsotm.TrackLists[0].OnGetTracks += FillDarkSideOfTheMoon;
        //    ziggy.TrackLists[0].OnGetTracks += FillZiggyStardust;
        //    displayFactory<AlbumFactoryBase, TrackListBase>(null, dsotm, ziggy);

        //    sender.Add("Side 1", "Speak to Me / Breathe");
        //    sender.Add("Side 1", "On The Run");
        //    sender.Add("Side 1", "Time");
        //    sender.Add("Side 1", "Any Colour You Like");
        //    sender.Add("Side 1", "The Great Gig In The Sky");
        //    sender.Add("Side 2", "Money");
        //    sender.Add("Side 2", "Us and Them");
        //    sender.Add("Side 2", "Brain Damage");
        //    sender.Add("Side 2", "Eclipse");
        //}
    }
}
