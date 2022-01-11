using System;
using System.Collections.Generic;
using System.Linq;

namespace CustomTypes.OnlineShop.Part3
{
    public class OnlineShop : IOnlineShop
    {
        private IInventoryManager invManager;
        private IOrderManager orderManager;
        private IPaymentManager payManager;
        private ILogManager logManager;

        private List<OnlineOrder> orders;
        public OnlineOrder[] Orders => orders.ToArray();
        
        public OnlineShop(IInventoryManager invManager, IOrderManager orderManager, IPaymentManager payManager, ILogManager logManager)
        {
            this.invManager = invManager;
            this.orderManager = orderManager;
            this.payManager = payManager;
            this.logManager = logManager;
            orders = new List<OnlineOrder>();
        }

        public bool Checkout(Dictionary<string, decimal> basket)
        {
            foreach (var kvp in basket)
            {
                var order = orderManager.Create(kvp.Key, kvp.Value);
                logManager.Write($"Order of {kvp.Key} @ {kvp.Value:C} created");
                orders.Add(order);
            }

            var totalDue = orders.Sum(order => order.Price);
            var paymentOkay = payManager.Pay(totalDue);
            if (paymentOkay)
            {
                logManager.Write($"{totalDue:C} received for order");
            }
            else
            {
                logManager.Write("Payment failed");
            }

            return paymentOkay;
        }
        public void LoadInventory()
        {
            invManager.Load();
        }
    }
}
