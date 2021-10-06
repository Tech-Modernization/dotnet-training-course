using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DemoKata.CustomTypes
{
    public class Order
    {
        private List<OrderItem> items;
        private decimal total;

        public Order()
        {
            total = 0.0M;
            items = new List<OrderItem>();
        }

        public void Add(DrinkBase drink)
        {
            var notFound = false;
            var item = findOrderItem(drink, out notFound) ?? new OrderItem(drink);

            item.Quantity++;
            item.CalcSubtotal();

            if (notFound) 
            {
                items.Add(item);
            }
        }

        private OrderItem findOrderItem(DrinkBase drink, out bool notFound)
        {
            notFound = false;
            foreach(var item in items)
            {
                if (item.Drink.Name == drink.Name)
                {
                    return item;
                }
            }

            notFound = true;
            return null;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            foreach (var item in items)
            {
                total += item.CalcSubtotal();
                sb.AppendLine($"{item.Quantity} x {item.Drink.Name} = {item.Subtotal:C}");
            }
            sb.AppendLine($"Total amount due = {total:C}");

            return sb.ToString();
        }
    }
}
