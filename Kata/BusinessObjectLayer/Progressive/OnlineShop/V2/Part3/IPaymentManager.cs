using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessObjectLayer.Progressive.OnlineShop.V2
{
    public interface IPaymentManager
    {
        PaymentResult Pay(OnlineOrder order);
    }
}
