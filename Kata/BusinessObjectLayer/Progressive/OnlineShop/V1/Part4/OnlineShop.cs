using Helpers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BusinessObjectLayer.OnlineShop.Part4
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

        public bool Checkout(OnlineBasket basket)
        {
                var order = orderManager.Create(basket);
                logManager.Write($"Order created {order}");
                orders.Add(order);
            

            var paymentOkay = payManager.Pay(order.Total);
            if (paymentOkay)
            {
                logManager.Write($"{order.Total:C} received for order");
            }
            else
            {
                logManager.Write("Payment failed");
            }

            return paymentOkay;
        }

        public OnlineBasket Browse()
        {
            var basket = new OnlineBasket();
            var menu = new MenuHelper();
            var selected = 0;
            do
            {
                menu.Clear();
                var prodText = string.Empty;
                var stringOkay = ConsoleHelper.GetString("Search the shop: ", out prodText);
                var matches = invManager.GetProducts(prodText);
                if (matches.Count == 0)
                {
                    Console.WriteLine("No product matches.");
                    continue;
                }

                var i = 1;
                menu.Build(() => matches.Select(m => new MenuItemBase() { Index = i++, Text = $"{m.Name} ({m.Price:C})" }).ToList());
                var skipOption = menu.AddOption("Search again");
                var quitOption = menu.AddOption("Abandon basket");
                selected = menu.SelectFromMenu("Select one of these or skip to search again");

                if (selected == quitOption)
                {
                    basket.Clear();
                    break;
                }

                if (selected == skipOption) continue;

                var quantity = 0;
                var quanOk = ConsoleHelper.GetInteger("How many? [1]: ", out quantity);
                if (quanOk)
                {
                    var prod = matches[selected - 1];
                    basket.Add(new OnlineBasketItem(prod.Name, prod.Price, quantity));
                }
            }
            while (menu.Settings.ExitOption != selected);

            return basket;
        }

    }
}
