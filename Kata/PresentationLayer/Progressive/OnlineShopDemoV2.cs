using System;
using System.Collections.Generic;
using System.Text;

namespace PresentationLayer.Progressive
{
    public class OnlineShopDemoV2 : DemoBase
    {
        public override void Run()
        {
            AddPart(Part1, "Initial stage of interface-first approach");
            base.Run();
        }

        public void Part1()
        {
            var shop = new OnlineShop();
            var inv = shop.LoadInventory();
            var basket = shop.SelectProducts(inv);
            var order = shop.CreateOrder(basket);
            var result = shop.TakePayment(order);
        }
    }
}
