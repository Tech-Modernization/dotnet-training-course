using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessObjectLayer.Bartender
{
    public class Order
    {
        public Payment Payment { get; }

        public object CreatePayment(decimal v)
        {
            throw new NotImplementedException();
        }

        public object GetPaymentMethod()
        {
            throw new NotImplementedException();
        }
    }
}
