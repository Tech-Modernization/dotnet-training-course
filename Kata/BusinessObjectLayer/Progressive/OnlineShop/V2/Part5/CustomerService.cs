using BusinessObjectLayer.Bartender;
using Helpers;
using Microsoft.VisualBasic;
using System;
using System.IO;
using System.Linq;

namespace BusinessObjectLayer.Progressive.OnlineShop.V2.Part5
{
    public class CustomerService : ICustomerService
    {
        private IJsonDataService dataService;
        private IInteractor interactor;
        private CustomerDb custDb;
        private string dbPath = @"online-shop-customers.json";

        public CustomerService(IJsonDataService dataService, IInteractor interactor)
        {
            this.dataService = dataService;
            this.interactor = interactor;

            custDb = Load(dbPath);
        }

        public void SaveBasket(OnlineBasket basket, CustomerProfile customer = null)
        {
            if (customer == null)
            {
                customer = EstablishCustomerContext(CustomerDecision.SaveAndQuit);
                if (customer != null)
                {
                    customer.SavedBasket = basket;
                    interactor.Message($"Basket saved.  Come back and check out soon, {customer.Email}");
                }
            }
        }

        public CustomerProfile Login()
        {
            var username = string.Empty;
            var gotEmail = interactor.GetString("Email: ", out username);
            if (gotEmail)
            {
                var customer = custDb.Customers.SingleOrDefault(customer => customer.Email == username);
                if (customer == null)
                {
                    customer = Register(username);
                }
                return customer;
            }
            return null;
        }

        private CustomerProfile Register(string username)
        {
            return new CustomerProfile(username, "xyz");
        }

        private CustomerDb Load(string path)
        {
            try
            {
                var jsonObj = dataService.GetJsonObject(path);
                return jsonObj.ToObject<CustomerDb>();
            }
            catch (FileHelperException ex)
            {
                if (ex.InnerException is FileNotFoundException)
                {
                    return new CustomerDb();
                }
                throw;
            }
        }

        public CustomerProfile EstablishCustomerContext(CustomerDecision decision)
        {
            var prompt = decision == CustomerDecision.Checkout
                ? "[L]ogin or [C]heckout as a guest? : "
                : "You must login to save your basket.  Do that now? [Y/N] : ";

            var keys = decision == CustomerDecision.Checkout
                ? new ConsoleKey[] { ConsoleKey.L, ConsoleKey.C }
                : new ConsoleKey[] { ConsoleKey.Y, ConsoleKey.N };

            var key = interactor.GetKey(prompt, true, keys);
            if (key == ConsoleKey.Q) return null;
            switch (key)
            {
                case ConsoleKey.Y:
                case ConsoleKey.L:
                    return Login();
                case ConsoleKey.C:
                    return new CustomerProfile("guest@shop.com", "abc");
                default:
                    return null;
            }
        }
    }
}