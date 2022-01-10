using System.Collections.Generic;

namespace CustomTypes.OnlineShop.Part3
{
    public interface IOnlineShop
    {
        bool Checkout(Dictionary<string, decimal> basket);
    }
}