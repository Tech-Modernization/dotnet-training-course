using System;
using System.Collections.Generic;
using System.Text;

namespace Kata.CustomTypes.OnlineShop.Part3
{
    public class OnlineShop
    {
        public List<OnlineOrder> Orders = new List<OnlineOrder>();

        public void LoadInventory()
            {
            Console.WriteLine("Loading the inventory");
                
        }
        public void CreateOrder()
        {
            Console.WriteLine("Creating new order");
        }

        public void TakePayment()
        {
            Console.WriteLine("Taking a payment");
        }
    }
}
