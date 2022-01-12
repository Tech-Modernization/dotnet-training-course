namespace BusinessObjectLayer.OnlineShop.Part4
{
    public class OnlineBasketItem : Product
    {
        public int Quantity { get; set; }
        public OnlineBasketItem(string name, decimal price, int quantity) : base(name, price)
        {
        }
    }
}