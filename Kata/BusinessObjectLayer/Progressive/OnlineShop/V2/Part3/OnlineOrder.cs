using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessObjectLayer.Progressive.OnlineShop.V2
{
    // Resp: encaps. order details.
    public class OnlineOrder
    {
        public string OrderId { get; }
        public DateTime Created { get; }
        public decimal Total { get; }
        public bool Paid { get; }
    }
}
