using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessObjectLayer.Progressive.OnlineShop.V2
{
    // resp: product selection
    public interface IShopAssistant
    {
        OnlineBasket Browse();
    }
}
