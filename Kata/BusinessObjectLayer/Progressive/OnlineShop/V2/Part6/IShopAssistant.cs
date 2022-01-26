using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessObjectLayer.Progressive.OnlineShop.V2.Part6
{
    // resp: product selection
    public interface IShopAssistant
    {
        CustomerDecision Browse(out OnlineBasket basket);
    }
}
