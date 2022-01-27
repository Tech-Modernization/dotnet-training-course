using System;

namespace BusinessObjectLayer.Progressive.OnlineShop.V2.Part7
{
    public class GooglePaymentMethod : IPaymentMethod, IOnlinePaymentMethod
    {
        public string Name { get; }

        public GooglePaymentMethod(string name)
        {
            Name = name;
        }

        public PaymentResult ProcessPayment(CustomerProfile customer, OnlineOrder order)
        {
            throw new NotImplementedException();
        }

        public bool Authenticate(string cardNumber, DateTime expiry, string cvv)
        {
            throw new NotImplementedException();
        }

        public PaymentResult Pay(decimal amount)
        {
            throw new NotImplementedException();
        }
    }
}