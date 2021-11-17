using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kata.CustomTypes.OnlineShop.Part5
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

    }
}
