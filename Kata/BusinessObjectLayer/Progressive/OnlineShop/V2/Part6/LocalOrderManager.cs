using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessObjectLayer.Progressive.OnlineShop.V2.Part6
{
    // resp: manage orders
    public class LocalOrderManager :  IOrderManager
    {
        public OnlineOrder Create(OnlineBasket basket)
        {
            return new OnlineOrder(basket);
        }
    }
}
