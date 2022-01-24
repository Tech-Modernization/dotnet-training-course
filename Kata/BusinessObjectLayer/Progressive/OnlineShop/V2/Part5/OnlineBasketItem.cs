namespace BusinessObjectLayer.Progressive.OnlineShop.V2.Part5
{
    // Resp: encapsulate and products and quantities given by the customer.
    public class OnlineBasketItem
    {
        public Product Product { get; }
        public int Quantity { get; internal set; }
        public OnlineBasketItem(Product product, int quantity)
        {
            Product = product;
            Quantity = quantity;
        }
    }
}