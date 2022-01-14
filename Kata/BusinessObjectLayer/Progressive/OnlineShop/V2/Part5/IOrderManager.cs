using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessObjectLayer.Progressive.OnlineShop.V2.Part5
{
    public interface IOrderManager
    {
        OnlineOrder Create(OnlineBasket basket);
    }
}
