using System;

namespace BusinessObjectLayer.Progressive.OnlineShop.V2.Part6
{
    public class MastercardPaymentMethod : IPaymentMethod
    {
        public string Name { get; }

        public MastercardPaymentMethod(string name)
        {
            Name = name;
        }

        public bool Authenticate(string cardNumber, DateTime expiry)
        {
            return (cardNumber.StartsWith("47") && expiry.Subtract(DateTime.Now).TotalDays > 0);
        }

        public bool SendPayment(decimal amount)
        {
            return amount < 500M;
        }
    }
}