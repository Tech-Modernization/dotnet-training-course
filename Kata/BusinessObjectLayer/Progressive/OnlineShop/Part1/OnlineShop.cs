using System;
using System.Collections.Generic;
using System.Text;

namespace CustomTypes.OnlineShop.Part1
{
    public class OnlineShop
    {
        public List<OnlineOrder> Orders { get; }

        public OnlineShop()
        {
            Orders = new List<OnlineOrder>();
        }
    }
}
