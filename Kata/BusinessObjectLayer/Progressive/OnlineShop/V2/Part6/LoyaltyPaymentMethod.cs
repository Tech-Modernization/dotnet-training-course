using System;

namespace BusinessObjectLayer.Progressive.OnlineShop.V2.Part6
{
    public class LoyaltyPaymentMethod : IPaymentMethod
    {
        public string Name { get; }
        public LoyaltyPaymentMethod(string name)
        {
            Name = name;
        }

        public bool Authenticate(string cardNumber, DateTime expiry)
        {
            return true;
        }

        public bool SendPayment(decimal amount)
        {
            throw new NotImplementedException();
        }
        public bool SendPayment(decimal amount, int points)
        {
            return points / 10 >= amount;
        }
    }
}