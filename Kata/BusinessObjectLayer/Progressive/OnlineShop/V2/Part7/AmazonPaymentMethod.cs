using System;

namespace BusinessObjectLayer.Progressive.OnlineShop.V2.Part7
{
    public class AmazonPaymentMethod : IOnlinePaymentMethod, IPaymentMethod
    {
        public AmazonPaymentMethod(string name)
        {
            Name = name;
        }

        public string Name { get; }

        public PaymentResult ProcessPayment(CustomerProfile customer, OnlineOrder order)
        {
            throw new System.NotImplementedException();
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