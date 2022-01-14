namespace BusinessObjectLayer.Progressive.OnlineShop.V2.Part5
{
    // resp: product selection
    public class ShopAssistant : IShopAssistant
    {
        
        public CustomerDecision Browse(out OnlineBasket basket)
        {
            basket = new OnlineBasket();
            var decision = default(CustomerDecision);
            while (/* TODO: setup the enum */)
            {
                // get user search string
                // if blank, do they wanna quit/checkout/search again?
                // if quit, do they wanna save their basket?
                // if checkout return basket
                // if search again continue
                // search inventory
                // if no results do they wanna quit/checkout/search again
                // (same conditional code as before)
                // display results
                // do they wanna add to basket/search again/checkout/quit
                // (product availability handshake)
                // (same conditional code + add to basket branch)
            }

            return default(CustomerDecision);
        }

        private CustomerDecision GetCustomerDecision(string prompt, params CustomerDecision[] options)
        {
            return default(CustomerDecision);
        }

        private CustomerDecision QuitWithoutSaving()
        { 
            return default(CustomerDecision);
        }

        private void AddToBasket(Product product, OnlineBasket basket) { }
    }
}