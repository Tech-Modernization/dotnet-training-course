using System.Collections.Generic;

namespace CustomTypes.OnlineShop.Part2
{
    public class OnlineShop
    {
        public List<OnlineOrder> Orders { get; }

        public OnlineShop()
        {
            Orders = new List<OnlineOrder>();
        }

        public void LoadInventory()
        {
            //Console.WriteLine("Load inventory");
        }

        public void TakePayment()
        {
            //Console.WriteLine("Taking payment");
        }

        public void CreateOrder(string productName, decimal price)
        {
           /* Console.WriteLine($"Creating order of {productName} @{price:C} each");
            Orders.Add(new OnlineOrder(productName, price));
           */
        }
    }
}
