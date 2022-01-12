using System;
using System.Linq;
using System.Text;

namespace BusinessObjectLayer.OnlineShop.Part4
{
    public class OnlineOrder
    {
        Guid orderId;
        DateTime created;
        OnlineBasket basket { get; }
        public bool Paid { get; set; }
        public decimal Total => basket.Sum(item => item.Price * item.Quantity);

        public OnlineOrder(OnlineBasket basket)
        {
            orderId = Guid.NewGuid();
            created = DateTime.Now;
            this.basket = basket;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Order {orderId} created {created:G}\n\n");
            foreach (var item in basket)
            {
                sb.AppendLine($"   {item.Quantity}    {item.Name}   @ {item.Price:C}  =  {item.Quantity * item.Price:C}");
            }
            sb.AppendLine($"\n\nTotal amount due: {Total:C}");
            return sb.ToString();
        }
    }
}
