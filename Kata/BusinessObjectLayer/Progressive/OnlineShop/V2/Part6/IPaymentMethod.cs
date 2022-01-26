using System;

namespace BusinessObjectLayer.Progressive.OnlineShop.V2.Part6
{
    public interface IPaymentMethod
    {
        string Name { get; }
        bool Authenticate(string cardNumber, DateTime expiry);
        bool SendPayment(decimal amount);
    }
}