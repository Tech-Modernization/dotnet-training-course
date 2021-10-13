using System;
using System.Collections.Generic;
using Kata.Demos;
using Kata.CustomTypes.MenuFactoryList;

namespace Kata
{
    class Program
    {
        static void Main(string[] args)
        {
            var demo = new MenuFactoryDemo(new DrinksMenu(), new FoodMenu());
            demo.Run();
        }

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

        static void displayFactory<TAbstractCreator, TAbstractProduct>(string propName, params TAbstractCreator[] creators)
        {
            if (string.IsNullOrEmpty(propName))
            {
                propName = $"{typeof(TAbstractProduct).Name.Replace("Base", "")}s";
            }

            foreach (var c in creators)
            {
                Console.WriteLine(c);
                foreach (var p in (List<TAbstractProduct>) c.GetType().GetProperty(propName)?.GetValue(c))
                {
                    Console.WriteLine($"    {p}");
                }
            }
        }
    }
}
