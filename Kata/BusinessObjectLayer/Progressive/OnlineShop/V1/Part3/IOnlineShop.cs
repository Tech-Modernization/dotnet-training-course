using System.Collections.Generic;

namespace BusinessObjectLayer.OnlineShop.Part3
{
    public interface IOnlineShop
    {
        bool Checkout(Dictionary<string, decimal> basket);
    }
}