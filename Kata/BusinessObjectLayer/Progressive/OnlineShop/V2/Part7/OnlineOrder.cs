using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjectLayer.Progressive.OnlineShop.V2.Part7
{
    // Resp: encaps. order details.
    public class OnlineOrder
    {
        public string OrderId { get; }
        public DateTime Created { get; }
        public decimal Total { get; }
        public bool Paid { get; internal set; }
        public List<OnlineBasketItem> Items { get; }

        public OnlineOrder(List<OnlineBasketItem> items)
        {
            Items = items;
            Total = items.Sum(item => item.Quantity * item.Product.Price);
            Created = DateTime.Now;
            OrderId = Guid.NewGuid().ToString();
        }
    }
}
