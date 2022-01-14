using System;

namespace BusinessObjectLayer.Progressive.OnlineShop.V2.Part4
{
    public class OnlineShop : IShopContainer
    {
        private IShopAssistant shopAssistant;
        private IOrderManager orderManager;
        private IPaymentManager payManager;
        private ISecurityManager secManager;
        
        public OnlineShop(IShopAssistant shopAssistant, IOrderManager orderManager, IPaymentManager payManager, ISecurityManager secManager)
        {
            this.shopAssistant = shopAssistant;
            this.orderManager = orderManager;
            this.payManager = payManager;
            this.secManager = secManager;
        }

        public void ServeCustomer()
        {
            // TODO: refactor IShopAssistant.Browse to also provide user decision
            var basket = shopAssistant.Browse();
            // TODO: prompt for login etc depending on browse status
            Checkout(basket);
        }


        private void Checkout(OnlineBasket basket)
        {
            var order = orderManager.Create(basket);
            var payResult = payManager.Pay(order);
        }
    }
}
