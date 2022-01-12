namespace BusinessObjectLayer.OnlineShop.Part4
{
    public interface IPaymentManager
    {
        bool Pay(decimal total);
    }
}