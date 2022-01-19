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
                decision = GetBrowseDecision(searchResults, basket);
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

        private CustomerDecision AddToBasket(Product product, OnlineBasket basket) 
        {
            var keys = new List<ConsoleKey>();
            for (var i = 1; i < 10; i++)
                keys.Add((ConsoleKey)i + 48);

            var key = interactor.GetKey($"How many {product.Name}s would you like? Enter 1-9: ", keys.ToArray());
            if (key == ConsoleKey.Q)
            {
                return QuitWithoutSaving();
            }

            basket.Add(new OnlineBasketItem(product, (int)key - 48));
            return CustomerDecision.AddToBasket;
        }

        private CustomerDecision GetBrowseDecision(List<Product> results, OnlineBasket basket)
        {
            var key = default(ConsoleKey);
            var keyDecisionMap = new Dictionary<ConsoleKey, CustomerDecision>()
            {
                {ConsoleKey.Q, CustomerDecision.Quit},
                {ConsoleKey.S, CustomerDecision.Search },
                {ConsoleKey.C, CustomerDecision.Checkout }
            };

            // if no results do they wanna quit/checkout/search again
            if (results.Count == 0)
            {
                key = basket.Count == 0
                    ? interactor.GetKey("No matching products.  Do you want to [S]earch again or [Q]uit?")
                    : interactor.GetKey("No matching products.  Do you want to [C]heckout, [S]earch again or [Q]uit?");

                switch (key)
                {
                    case ConsoleKey.Q:
                        return QuitWithoutSaving();
                    case ConsoleKey.C:
                        return CustomerDecision.Checkout;
                    default:
                        return CustomerDecision.Search;
                }
            }

            if (results.Count > 9)
            {
                interactor.Message($"Too many results.  Please refine your search.");
                return CustomerDecision.Search;
            }


            interactor.Message($"{results.Count} product{(results.Count == 1 ? "" : "s")} found\n\n");
            // display results
            interactor.Message($"Products found: \n{string.Join("\n", results.Select(p => $"{p.Name}: {p.Price:C}"))}");

            var decision = CustomerDecision.AddToBasket;
            while (decision == CustomerDecision.AddToBasket)
            {
                // do they wanna add to basket/search again/checkout/quit
                var promptString = $"Select a product to add to your basket with [1] to [{results.Count}], [C]heckout, [S]earch again or [Q]uit";
                var keysAllowed = new List<ConsoleKey>();
                for (var i = 0; i < results.Count; i++)
                {
                    var asciiValue = i + 1 + 48;
                    keysAllowed.Add((ConsoleKey)asciiValue);
                }
                keysAllowed.Add(ConsoleKey.S);
                keysAllowed.Add(ConsoleKey.C);

                key = interactor.GetKey(promptString, keysAllowed.ToArray());
                if (char.IsLetter((char)key))
                {
                    return keyDecisionMap[key];
                }

                // (product availability handshake)
                // the only option left now is adding to the basket
                var resultIndex = (int)key - 49;
                decision = AddToBasket(results[resultIndex], basket);

                if (results.Count == 1 && decision == CustomerDecision.AddToBasket)
                {
                    return CustomerDecision.Search;
                }
            }
            return decision;
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