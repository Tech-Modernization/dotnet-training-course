using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessObjectLayer.OnlineShop.Part4
{
    public class LocalOrderManager :  IOrderManager
    {
        public OnlineOrder Create(OnlineBasket basket)
        {
            return new OnlineOrder(basket);
        }
    }
}
