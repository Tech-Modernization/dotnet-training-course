using System;

namespace BusinessObjectLayer.Progressive.OnlineShop.V2.Part6
{
    public class VisaPaymentMethod : IPaymentMethod
    {
        public string Name { get; }
        public VisaPaymentMethod(string name)
        {
            Name = name;
        }
        public bool Authenticate(string cardNumber, DateTime expiry)
        {
            return (cardNumber.StartsWith("49") && expiry.Subtract(DateTime.Now).TotalDays > 0);
        }

        public bool SendPayment(decimal amount)
        {
            return amount < 250.0M;
        }

        public PaymentResult ProcessPayment(CustomerProfile customer, OnlineOrder order)
        {
            throw new NotImplementedException();
        }
    }
}