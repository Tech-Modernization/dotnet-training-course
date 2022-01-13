using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessObjectLayer.Progressive.OnlineShop.V2
{
    public class ShopAssistant : IShopAssistant
    {
        public OnlineBasket Browse()
        {
            throw new NotImplementedException();
        }
    }
    public class OnlineShop : IShopContainer
    {
        public void Enter(Customer cust)
        {
            throw new NotImplementedException();
        }

        public OnlineBasket Browse()
        {
            var shopAssistant = new ShopAssistant();
            return shopAssistant.Browse();
        }

        public void Checkout(OnlineBasket basket)
        {
            throw new NotImplementedException();
        }
    }
}
