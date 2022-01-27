namespace BusinessObjectLayer.Progressive.OnlineShop.V2.Part7
{
    public interface IRewardPaymentMethod
    {
        PaymentResult Pay(RewardProfile profile);
    }
}