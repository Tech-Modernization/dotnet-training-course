using BusinessObjectLayer.Progressive.OnlineShop.V2;
using Helpers;
using System;
using System.Collections.Generic;
using System.Text;

using Part3 = BusinessObjectLayer.Progressive.OnlineShop.V2.Part3;
using Part4 = BusinessObjectLayer.Progressive.OnlineShop.V2.Part4;
using Part5 = BusinessObjectLayer.Progressive.OnlineShop.V2.Part5;
using Part6 = BusinessObjectLayer.Progressive.OnlineShop.V2.Part6;

/*                              
 *       --------------------------                   
 *       0000 0000 0000 0000 
 *       0001 0000 0000 0100
 *       0000 0000 0000 0001
 *                         |
 *                         ^ bit 1 reps having a cup of tea 
 *          |            |
 *          |            ^ bit 3 reps adding a new line 
 *          ^ bit 13 represent add quit option 
 *                       
 *       NoNewLine = 4
 *       AddQuit = 4096
 *       
 *       mask = 4100
 *       
 *       mask of all 3 = 4101
 *       
 *       0000 0000 0000 0001  HaveTea
 *       0001 0000 0000 0000  AddQuit
 *       0000 0000 0000 0100  NoNewLine
 *       
 *       0001 0000 0000 0101  allFlags
 *       
 *       AddQuit & NoNewLine  = 0
 *       
 *       0001 0000 0000 0100  AddQuit | NoNewLine ("twoFlags")
 *       
 *       allFlags = HaveTea|AddQuit|NoNewLine; (4101)
 *       
 *       if (allFlags & (AddQuit|NoNewLine) == AddQuit|NoNewLine)
 *       
 *       bool HasAddQuit = allFlags & AddQuit == AddQuit
 *       
 */

namespace PresentationLayer.Progressive
{
    public class OnlineShopDemoV2 : DemoBase
    {
        public override void Run()
        {
            Console.Clear();

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
                var cus = new Part5.CustomerService(json, con);
                var shop = new Part5.OnlineShop(ass, ord, pay, con, cus);
                shop.ServeCustomer();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unable to open the shop due to: \n");
                var indent = "   ";
                while (ex != null)
                {
                    Console.WriteLine($"{indent}{ex.Message}");
                    indent = $"   {indent}";
                    ex = ex.InnerException;
                }
            }
        }

        public void Part6()
        {
            try
            {
                var json = new Part6.LocalJsonDataService();
                var inv = new Part6.JsonInventoryManager(json);
                var con = new Part6.ConsoleInteractor();
                var aud = new Part6.Auditor();
                var ass = new Part6.ShopAssistant(inv, con, aud);
                var ord = new Part6.LocalOrderManager();
                var visa = new Part6.VisaPaymentMethod("Visa");
                var mst = new Part6.MastercardPaymentMethod("Mastercard");
                var loy = new Part6.LoyaltyPaymentMethod("Loyalty Card");
                var methods = new List<Part6.IPaymentMethod>() { mst, visa, loy };
                var pay = new Part6.PaymentManager(con, methods);
                var cus = new Part6.CustomerService(json, con);
                var shop = new Part6.OnlineShop(ass, ord, pay, con, cus);
                shop.ServeCustomer();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unable to open the shop due to: \n");
                var indent = "   ";
                while (ex != null)
                {
                    Console.WriteLine($"{indent}{ex.Message}");
                    indent = $"   {indent}";
                    ex = ex.InnerException;
                }
            }
        }

        public void Part7()
        {

        }
    }
}
