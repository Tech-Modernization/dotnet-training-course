using System.Collections.Generic;

namespace BusinessObjectLayer.OnlineShop.Part4
{
    public interface IOnlineShop
    {
        OnlineBasket Browse();
        bool Checkout(OnlineBasket basket);
    }
}