using System;

namespace BusinessObjectLayer.Progressive.OnlineShop.V2.Part7
{
    public interface IOnlinePaymentMethod
    {
        bool Authenticate(string cardNumber, DateTime expiry, string cvv);
        PaymentResult Pay(decimal amount);
    }
}