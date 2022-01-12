using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessObjectLayer.OnlineShop.Part3
{
    public class LocalOrderManager :  IOrderManager
    {
        public OnlineOrder Create(string productName, decimal price)
        {
            return new OnlineOrder(productName, price);
        }
    }
}
