namespace CustomTypes.OnlineShop.Part1
{
    public class OnlineOrder
    {
        public string ProductName { get; }
        public decimal Price { get; }
        private bool paid;
        public bool Paid => paid;

        public OnlineOrder(string productName, decimal price)
        {
            ProductName = productName;
            Price = price;
        }
        public OnlineOrder(string productName, decimal price, bool paid) : this(productName, price)
        {
            this.paid = paid;
        }

        public void MarkAsPaid()
        {
            paid = true;
        }
    }
}
