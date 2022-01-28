using BusinessObjectLayer.Bartender;
using Helpers;
using Microsoft.VisualBasic;
using System;
using System.IO;
using System.Linq;

namespace BusinessObjectLayer.Progressive.OnlineShop.V2.Part7
{
    public class CustomerService : ICustomerService
    {
        private IJsonDataService dataService;
        private IInteractor interactor;
        private ShopDb shopDb;
        private const string dbPath = "online-shop-inventory.json";

        public CustomerService(IJsonDataService dataService, IInteractor interactor)
        {
            this.dataService = dataService;
            this.interactor = interactor;

            shopDb = Load(dbPath);
        }

        public void SaveBasket(OnlineBasket basket, CustomerProfile customer = null)
        {
            if (customer == null)
            {
                customer = EstablishCustomerContext(CustomerDecision.SaveAndQuit);
                if (customer != null)
                {
                    customer.SavedBasket = basket;
                    dataService.Save(dbPath, shopDb);
                    interactor.Message($"Basket saved.  Come back and check out soon, {customer.Name}");
                }
            }
        }

        private CustomerProfile GetCustomer()
        {
            var username = string.Empty;
            var gotEmail = interactor.GetString("Name: ", out username);
            return gotEmail 
                ? shopDb.Customers.SingleOrDefault(customer => customer.Name == username)
                : Register(username);
        }
        public CustomerProfile Login()
        {
            return GetCustomer();
        }

        private CustomerProfile Register(string username)
        {
            return new CustomerProfile(username);
        }

        private ShopDb Load(string path)
        {
            var jsonObj = dataService.GetJsonObject(path);
            return jsonObj.ToObject<ShopDb>();
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
                    return new CustomerProfile("guest@shop.com");
                default:
                    return null;
            }
        }

        public void Manage()
        {
            var key = interactor.GetKey("[A]dd, [E]dit or [D]elete customer? ", ConsoleKey.A, ConsoleKey.E, ConsoleKey.D);
            switch(key)
            {
                case ConsoleKey.E:
                case ConsoleKey.A:
                    AddCustomer();
                    break;
                case ConsoleKey.D:
                    DeleteCustomer();
                    break;
            }

            dataService.Save(dbPath, shopDb);
        }

        private void AddCustomer()
        {
            var customer = GetCustomer();
            if (customer != null)
            {
                if (customer.IsNew)
                {
                    shopDb.Customers.Add(customer);
                }
                else
                {
                    EditCustomer(customer);
                }
            }
        }

        private void DeleteCustomer()
        {
            var cust = GetCustomer();
            if (cust != null)
            {
                shopDb.Customers.Remove(cust);
            }
        }

        private void EditCustomer(CustomerProfile customer)
        {
            throw new NotImplementedException();
        }
    }
}