using System;
using System.Collections.Generic;
using System.Linq;

namespace BusinessObjectLayer.Progressive.OnlineShop.V2.Part5
{
    // resp: product selection
    public class ShopAssistant : IShopAssistant
    {
        private IInventoryManager invManager;
        private IInteractor interactor;
        private IAuditor auditor;

        public ShopAssistant(IInventoryManager invManager, IInteractor interactor, IAuditor auditor)
        {
            this.invManager = invManager;
            this.interactor = interactor;
            this.auditor = auditor;
        }

        public CustomerDecision Browse(out OnlineBasket basket)
        {
            basket = new OnlineBasket();
            var decision = default(CustomerDecision);
            var exitOptions = new[]
            {
                CustomerDecision.Quit,
                CustomerDecision.SaveAndQuit,
                CustomerDecision.Checkout
            };

            while (!exitOptions.Contains(decision))
            {
                var searchString = string.Empty;
                decision = GetSearchString(ref searchString);
                if (decision != CustomerDecision.Search) continue;

                var searchResults = invManager.Search(searchString);
                decision = GetBrowseDecision(searchResults);
            }

            if (decision == CustomerDecision.Quit)
            {
                // discard the basket
                basket = null;
            }

            return decision;
        }

        private CustomerDecision GetCustomerDecision(string prompt, params CustomerDecision[] options)
        {
            return default(CustomerDecision);
        }

        private CustomerDecision QuitWithoutSaving()
        {
            var key = interactor.GetKey("Do you want to [S]ave your basket or [Q]uit without saving? : ", ConsoleKey.S);
            return key == ConsoleKey.S ? CustomerDecision.SaveAndQuit : CustomerDecision.Quit;
        }

        private void AddToBasket(Product product, OnlineBasket basket) 
        { 
        }

        private CustomerDecision GetBrowseDecision(List<Product> results)
        {
            // if no results do they wanna quit/checkout/search again
            if (results.Count == 0)
            {
                var key = interactor.GetKey("No matching products.  Do you want to [Q]uit or [S]earch again?");
                if (key == ConsoleKey.Q)
                {
                    return QuitWithoutSaving();
                }
                return CustomerDecision.Search;
            }
            // (same conditional code as before)
            // display results
            // do they wanna add to basket/search again/checkout/quit
            // (product availability handshake)
            // (same conditional code + add to basket branch)
            Console.WriteLine($"Products found: \n{string.Join("\n", results.Select(p => $"{p.Name}: {p.Price:C}"))}");
            return CustomerDecision.Search;
        }

        private CustomerDecision GetSearchString(ref string searchString)
        {
            ConsoleKey key = default;
            while (true)
            {
                // get user search string
                searchString = interactor.GetString("Enter part of a product name or description: ");
                // if blank, do they wanna quit/checkout/search again?
                if (string.IsNullOrEmpty(searchString))
                {
                    key = interactor.GetKey("Do you want to [S]earch, [C]heckout or [Q]uit? : ", ConsoleKey.S, ConsoleKey.C);
                    if (key == ConsoleKey.S) continue;
                    if (key == ConsoleKey.Q)
                    {
                        // if quit, do they wanna save their basket?
                        return QuitWithoutSaving();
                    }
                    // if checkout return basket
                    return CustomerDecision.Checkout;
                }
                // we have a string!
                return CustomerDecision.Search;
            }
        }
    }
}