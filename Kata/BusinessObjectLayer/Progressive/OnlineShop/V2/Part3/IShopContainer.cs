using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessObjectLayer.Progressive.OnlineShop.V2
{
    public interface IShopContainer
    {
        void Enter(Customer cust);
        OnlineBasket Browse();
        void Checkout(OnlineBasket basket);
    }
}
