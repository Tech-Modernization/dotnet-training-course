using BusinessObjectLayer.Progressive.OnlineShop.V2;
using System;
using System.Collections.Generic;
using System.Text;

using Part3 = BusinessObjectLayer.Progressive.OnlineShop.V2.Part3;
using Part4 = BusinessObjectLayer.Progressive.OnlineShop.V2.Part4;

namespace PresentationLayer.Progressive
{
    public class OnlineShopDemoV2 : DemoBase
    {
        public override void Run()
        {
            //AddPart(Part3, "Establish main components of the shop (Parts 1-3 in OnlineShop.docx)");
            AddPart(Part4, "Get an end-to-end high level process to run");
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
    }
}
