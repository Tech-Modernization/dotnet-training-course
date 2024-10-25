﻿using System;
using System.Collections.Generic;
using System.Linq;

using Helpers;
using ImplementationLayer;
using Part1 = BusinessObjectLayer.OnlineShop.Part1;
using Part2 = BusinessObjectLayer.OnlineShop.Part2;
using Part3 = BusinessObjectLayer.OnlineShop.Part3;
using Part4 = BusinessObjectLayer.OnlineShop.Part4;
//using Part5 = BusinessObjectLayer.OnlineShop.Part5;
//using Part6 = BusinessObjectLayer.OnlineShop.Part6;

namespace PresentationLayer
{
    public class OnlineShopDemoV1 : DemoBase
    {
        Dictionary<string, decimal> basket = new Dictionary<string, decimal>
            {
                {"t-shirt", 10.50M},
                {"jeans", 30.99M},
                {"beanie", 14.00M}
            };

        public override void Run()
        {
        //    AddPart(Part1, "Define basic classes");
         //   AddPart(Part2, "Enable the shop to load an inventory, create orders and take payments");
           // AddPart(Part3, "Separating order, payment, inventory and logging concerns");
            
                AddPart(Part4, "Search products and check out a basket");
            /*    AddPart(Part5, "Demonstrate violation of DIP");
                AddPart(Part6, "Resolve violation of DIP with InventoryService and CsvDataService");
            */
            base.Run();
        }
        public void Part1()
        {
            var shop = new Part1.OnlineShop();
            shop.Orders.Add(new Part1.OnlineOrder("t-shirt", 10.50M));
            shop.Orders.Add(new Part1.OnlineOrder("jeans", 30.99M));
            shop.Orders.Add(new Part1.OnlineOrder("beanie", 14.00M, true));

            foreach (var order in shop.Orders)
            {
                dbg($"Order of {order.ProductName}: amount of {order.Price:C} {(order.Paid ? "received" : "due")}");
            }
        }

        public void Part2()
        {
            var shop = new Part2.OnlineShop();
        
            shop.LoadInventory();
            foreach(var kvp in basket)
            {
                shop.CreateOrder(kvp.Key, kvp.Value);
            }

            shop.Orders.Single(o => o.ProductName == "beanie").MarkAsPaid();
            //    shop.Orders.SingleOrDefault(o => o.ProductName == "beanie")?.MarkAsPaid();
            //
            //  equivalent of:
            //
            //     var beanieOrder = shop.Orders.SingleOrDefault(o => o.ProductName == "beanie");
            //     if (beanieOrder != null)
            //     {
            //         beanieOrder.MarkAsPaid();
            //     }

            foreach (var order in shop.Orders)
            {
                dbg($"Order of {order.ProductName}: amount of {order.Price:C} {(order.Paid ? "received" : "due")}");
            }
        }
        
        public void Part3()
        {
            var invManager = new Part3.LocalInventoryManager();
            var payManager = new Part3.LocalPaymentManager();
            var orderManager = new Part3.LocalOrderManager();
            var logManager = new Part3.LocalLogManager();

            var shop = new Part3.OnlineShop(invManager, orderManager, payManager, logManager);
            Console.WriteLine($"Basket {(shop.Checkout(basket) ? "" : "not ")}checked out.");
        }

        
        public void Part4()
        {
            var invManager = new Part4.CsvInventoryManager(new FileDataService());
            var payManager = new Part4.LocalPaymentManager();
            var orderManager = new Part4.LocalOrderManager();
            var logManager = new Part4.LocalLogManager();

            var shop = new Part4.OnlineShop(invManager, orderManager, payManager, logManager);
            var basket = shop.Browse();
            if (basket.Count == 0)
            {
                Console.WriteLine("Basket abandoned");
                return;
            }

            shop.Checkout(basket);
        }

        /*
        public void Part5()
        {
            var invManager = new Part5.InventoryManager();
            invManager.Load();
            var products = invManager.Get();

            var menu = new MenuHelper();
            menu.Build(() => products.Select(p => new MenuItemBase { Index = products.IndexOf(p), Text = p.ToString() }).ToList());
            var productToAdd = menu.SelectFromMenu("Product selection: ");
        }
        public void Part6()
        {
            var dataService = new Part6.FileDataService();
            var invService = new Part6.CsvInventoryService(dataService);
            var invManager = new Part6.InventoryManager(invService);
            invManager.Load();
            var products = invManager.Get();

            var menu = new MenuHelper();
            menu.Build(() => products.Select(p => new MenuItemBase { Index = products.IndexOf(p), Text = p.ToString() }).ToList());
            var productToAdd = menu.SelectFromMenu("Product selection: ");
        }
        public void Part7()
        {
            var dataService = new Part6.FileDataService();
            var invService = new Part6.CsvInventoryService(dataService);
            var invManager = new Part6.InventoryManager(invService);
            invManager.Load();
            var products = invManager.Get();

            var menu = new MenuHelper();
            menu.Build(() => products.Select(p => new MenuItemBase { Index = products.IndexOf(p), Text = p.ToString() }).ToList());
            var productToAdd = menu.SelectFromMenu("Product selection: ");
        }
*/
    }
}
