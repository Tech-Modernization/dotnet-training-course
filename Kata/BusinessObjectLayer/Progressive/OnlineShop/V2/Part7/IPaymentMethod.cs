using System;

namespace BusinessObjectLayer.Progressive.OnlineShop.V2.Part7
{
    public interface IPaymentMethod
    {
        string Name { get; }
        PaymentResult ProcessPayment(CustomerProfile customer, OnlineOrder order);
    }
}