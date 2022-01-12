using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessObjectLayer.Progressive.OnlineShop.V2
{
    public class OnlineShop : IShopContainer
    {
        public void Enter(Customer cust)
        {
            throw new NotImplementedException();
        }

        public OnlineBasket Browse()
        {
            // delegate browsing to shop assistant.
            return assistant.Browse();
        }

        public void Checkout(OnlineBasket basket)
        {
            throw new NotImplementedException();
        }
    }
}
