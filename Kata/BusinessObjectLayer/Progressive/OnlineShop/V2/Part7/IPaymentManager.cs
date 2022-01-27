using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessObjectLayer.Progressive.OnlineShop.V2.Part7
{
    // resp: managing payments
    public interface IPaymentManager
    {
        PaymentResult ProcessPayment(CustomerProfile customer, OnlineOrder order);
    }
}
