using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessObjectLayer.OnlineShop.Part4
{
    public class LocalPaymentManager : IPaymentManager
    { 
        public bool Pay(decimal total)
        {
            return true;
        }
    }
}
