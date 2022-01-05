using System.Collections.Generic;
using System.Linq;

using Kata.Helpers;

using Part1 = CustomTypes.OnlineShop.Part1;
using Part2 = CustomTypes.OnlineShop.Part2;
//using Part3 = Kata.CustomTypes.OnlineShop.Part3;
//using Part4 = Kata.CustomTypes.OnlineShop.Part4;
//using Part5 = Kata.CustomTypes.OnlineShop.Part5;
//using Part6 = Kata.CustomTypes.OnlineShop.Part6;

namespace Kata.Demos
{
    public class OnlineShopDemo : DemoBase
    {
        public override void Run()
        {
        //    AddPart(Part1, "Define basic classes");
            AddPart(Part2, "Enable the shop to load an inventory, create orders and take payments");
        /*    AddPart(Part3, "Try to resolve SRP violation");
            AddPart(Part4, "Violate ISP and DIP, then resolve SRP, ISP and DIP violations");
            AddPart(Part5, "Demonstrate violation of DIP");
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
            var inv = new Dictionary<string, decimal>()
            {
                {"t-shirt", 10.50M},
                {"jeans", 30.99M},
                {"beanie", 14.00M}
            };
        
            shop.LoadInventory();
            foreach(var kvp in inv)
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
        /*
        public void Part3()
        {
            var shop = new Part3.OnlineShop();
            shop.Orders.Add(new Part3.OnlineOrder() { ProductName = "t-shirt", Price = 10.50M, Paid = false });
            shop.Orders.Add(new Part3.OnlineOrder() { ProductName = "jeans", Price = 30.99M, Paid = false });
            shop.Orders.Add(new Part3.OnlineOrder() { ProductName = "beanie", Price = 14.00M, Paid = true });

            foreach (var order in shop.Orders)
            {
                shop.LoadInventory();
                shop.CreateOrder();
                order.Paid = true;
                shop.TakePayment();
                dbg($"Order of {order.ProductName}: amount of {order.Price:C} {(order.Paid ? "received" : "due")}");
            }
        }
        public void Part4()
        {
            var invManager = new Part4.InventoryManager();
            var payManager = new Part4.PayPalPaymentManager();
            var orderManager = new Part4.LocalOrderManager();

            var shop = new Part4.OnlineShop(invManager, orderManager, payManager);
            shop.Orders.Add(new Part4.OnlineOrder() { ProductName = "t-shirt", Price = 10.50M, Paid = false });
            shop.Orders.Add(new Part4.OnlineOrder() { ProductName = "jeans", Price = 30.99M, Paid = false });
            shop.Orders.Add(new Part4.OnlineOrder() { ProductName = "beanie", Price = 14.00M, Paid = true });

            shop.Run();
        }

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
