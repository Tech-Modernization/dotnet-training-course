using System;

namespace BusinessObjectLayer.Progressive.OnlineShop.V2.Part7
{
    public class NectarPaymentMethod : IPaymentMethod, IRewardPaymentMethod
    {
        public string Name { get; }
        public NectarPaymentMethod(string name)
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

        public PaymentResult ProcessPayment(CustomerProfile customer, OnlineOrder order)
        {
            throw new NotImplementedException();
        }

        public PaymentResult Pay(RewardProfile profile)
        {
            throw new NotImplementedException();
        }
    }
}