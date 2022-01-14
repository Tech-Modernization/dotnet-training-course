using System;

namespace BusinessObjectLayer.Progressive.OnlineShop.V2.Part3
{
    public class OnlineShop : IShopContainer
    {
        private IShopAssistant shopAssistant;
        private IOrderManager orderManager;
        private IPaymentManager payManager;

        public OnlineShop(IShopAssistant shopAssistant, IOrderManager orderManager, IPaymentManager payManager)
        {
            this.shopAssistant = shopAssistant;
            this.orderManager = orderManager;
            this.payManager = payManager;
        }

        public void Enter(Customer cust)
        {
            throw new NotImplementedException();
        }

        public OnlineBasket Browse()
        {
            return null;
        }

        public void Checkout(OnlineBasket basket)
        {
            throw new NotImplementedException();
        }
    }
}
