using System;
using System.Collections.Generic;
using System.Text;

namespace CustomTypes.OnlineShop.Part3
{
    public class LocalPaymentManager : IPaymentManager
    { 
        public bool Pay(decimal total)
        {
            return true;
        }
    }
}
