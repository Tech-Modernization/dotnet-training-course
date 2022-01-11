namespace CustomTypes.OnlineShop.Part3
{
    public interface IOrderManager
    {
        OnlineOrder Create(string productName, decimal price);
    }
}