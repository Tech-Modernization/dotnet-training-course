namespace BusinessObjectLayer.OnlineShop.Part4
{
    public interface IOrderManager
    {
        OnlineOrder Create(OnlineBasket basket);
    }
}