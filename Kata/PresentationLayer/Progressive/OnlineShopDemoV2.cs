using BusinessObjectLayer.Progressive.OnlineShop.V2;
using System;
using System.Collections.Generic;
using System.Text;

using Part3 = BusinessObjectLayer.Progressive.OnlineShop.V2.Part3;
using Part4 = BusinessObjectLayer.Progressive.OnlineShop.V2.Part4;
using Part5 = BusinessObjectLayer.Progressive.OnlineShop.V2.Part5;

namespace PresentationLayer.Progressive
{
    public sealed class Thing
    {
        public string Name;

        public Thing(string name)
        {
            Name = name;
        }

        public override string ToString()
        {
            return $"Crazy little thing called {Name}";
        }
    }

    public static class ThingExtensions
    {
        public static string AltToString(this Thing thing, string format)
        {
            return string.Format(format, thing.Name);
        }

        public static List<int> ToAsciiList(this Thing thing)
        {
            var result = new List<int>();
            var name = thing.Name;
            foreach(char c in name)
            {
                result.Add(c);
            }
            return result;
        }
    }

    public class OnlineShopDemoV2 : DemoBase
    {
        public override void Run()
        {
            var thing = new Thing("Love");
            Console.WriteLine(thing);

            Console.WriteLine(thing.AltToString("{0} is a many-splendoured thing"));
            var asciiList = thing.AltToString("{0} is a many-splendoured thing").ToAsciiList();
            Console.WriteLine($"thing has these ascii values: {string.Join(", ", asciiList)}");

            thing = new Thing("c# extensions methods, rule all");
            asciiList = thing.ToAsciiList();
            Console.WriteLine($"thing has these ascii values: {string.Join(", ", asciiList)}");

            //AddPart(Part3, "Establish main components of the shop (Parts 1-3 in OnlineShop.docx)");
            // AddPart(Part4, "Get an end-to-end high level process to run");
            AddPart(Part5, "Implement the IShopAssistnt.Browse method (i)");
            base.Run();
        }

        public void Part3()
        {
            var shop = new Part3.OnlineShop(null, null, null);
            shop.Enter(null);
        }

        public void Part4()
        {
            var ass = new Part4.ShopAssistant();
            var ord = new Part4.LocalOrderManager();
            var pay = new Part4.LocalPaymentManager();
            var sec = new Part4.LocalSecurityManager();
            var shop = new Part4.OnlineShop(ass, ord, pay, sec);
            shop.ServeCustomer();
        }

        public void Part5()
        {
            try
            {
                var json = new Part5.LocalJsonDataService();
                var inv = new Part5.JsonInventoryManager(json);
                var con = new Part5.ConsoleInteractor();
                var aud = new Part5.Auditor();
                var ass = new Part5.ShopAssistant(inv, con, aud);
                var ord = new Part5.LocalOrderManager();
                var pay = new Part5.LocalPaymentManager();
                var sec = new Part5.LocalSecurityManager();
                var shop = new Part5.OnlineShop(ass, ord, pay, sec);
                shop.ServeCustomer();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unable to open the shop due to: \n {ex.Message}");
            }
        }
    }
}
