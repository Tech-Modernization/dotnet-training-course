using BusinessObjectLayer.Progressive.OnlineShop.V2;
using System;
using System.Collections.Generic;
using System.Text;

namespace PresentationLayer.Progressive
{
    public class OnlineShopDemoV2 : DemoBase
    {
        public override void Run()
        {
            AddPart(Part3, "Establish main components of the shop (Parts 1-3 in OnlineShop.docx)");
            base.Run();
        }

        public void Part3()
        {
            var shop = new OnlineShop();
            shop.Enter(null);
        }
    }
}
