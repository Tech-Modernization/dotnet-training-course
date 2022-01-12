namespace BusinessObjectLayer.OnlineShop.Part3
{
    public interface IPaymentManager
    {
        bool Pay(decimal total);
    }
}