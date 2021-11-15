using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kata.CustomTypes.OnlineShop.Part4
{
    public class OnlineShop : IOnlineShop
    {
        public List<OnlineOrder> Orders = new List<OnlineOrder>();

        private IInventoryManager invManager;
        private IOrderManager ordManager;
        private IPaymentManager payManager;

        public OnlineShop(IInventoryManager invManager, IOrderManager ordManager, IPaymentManager payManager)
        {
            this.invManager = invManager;
            this.ordManager = ordManager;
            this.payManager = payManager;
        }

        public void Run()
        {
            invManager.LoadInventory();
            foreach(var o in Orders)
            {
                Console.WriteLine($"Ordering {o.ProductName} @ {o.Price:C}");
                ordManager.AddToCart();
                    
            }
            Console.WriteLine($"Taking payment of total {Orders.Sum(o => o.Price):C}");
        }
    }
}
