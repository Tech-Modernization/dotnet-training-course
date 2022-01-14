using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessObjectLayer.Progressive.OnlineShop.V2.Part4
{
    // resp: managing payments
    public interface IPaymentManager
    {
        PaymentResult Pay(OnlineOrder order);
    }
}
