namespace BusinessObjectLayer.Progressive.OnlineShop.V2.Part7
{
    public class RewardProfile : IPaymentMethod, IRewardPaymentMethod
    {
        public PaymentResult Pay(RewardProfile profile)
        {
            throw new System.NotImplementedException();
        }

        public string Name { get; }

        public PaymentResult ProcessPayment(CustomerProfile customer, OnlineOrder order)
        {
            throw new System.NotImplementedException();
        }
    }
}