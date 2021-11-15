using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

using Part1 = Kata.CustomTypes.OnlineShop.Part1;
using Part2 = Kata.CustomTypes.OnlineShop.Part2;
using Part3 = Kata.CustomTypes.OnlineShop.Part3;
using Part4 = Kata.CustomTypes.OnlineShop.Part4;
//using Part5 = Kata.CustomTypes.OnlineShop.Part5;
//using Part6 = Kata.CustomTypes.OnlineShop.Part6;

namespace Kata.Demos
{
    public class OnlineShopDemo : DemoBase
    {
        public override void Run()
        {
            AddPart(Part1, "Define basic classes");
            AddPart(Part2, "Enable the shop to load an inventory, create orders and take payments");
            AddPart(Part3, "Try to resolve SRP violation");
            AddPart(Part4, "Violate ISP and DIP, then resolve SRP, ISP and DIP violations");
            base.Run();
        }
        public void Part1()
        {

            var shop = new Part1.OnlineShop();
            shop.Orders.Add(new Part1.OnlineOrder() { ProductName = "t-shirt", Price = 10.50M, Paid = false });
            shop.Orders.Add(new Part1.OnlineOrder() { ProductName = "jeans", Price = 30.99M, Paid = false });
            shop.Orders.Add(new Part1.OnlineOrder() { ProductName = "beanie", Price = 14.00M, Paid = true });

            foreach (var order in shop.Orders)
            {
                dbg($"Order of {order.ProductName}: amount of {order.Price:C} {(order.Paid ? "received" : "due")}");
            }
        }

        public void Part2()
        {
            var shop = new Part2.OnlineShop();
            shop.Orders.Add(new Part2.OnlineOrder() { ProductName = "t-shirt", Price = 10.50M, Paid = false });
            shop.Orders.Add(new Part2.OnlineOrder() { ProductName = "jeans", Price = 30.99M, Paid = false });
            shop.Orders.Add(new Part2.OnlineOrder() { ProductName = "beanie", Price = 14.00M, Paid = true });

            foreach (var order in shop.Orders)
            {
                shop.LoadInventory();
                shop.CreateOrder();
                order.Paid = true;
                shop.TakePayment();
                dbg($"Order of {order.ProductName}: amount of {order.Price:C} {(order.Paid ? "received" : "due")}");
            }
        }
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
            var invManager = new Part4.LocalInventoryManager();
            var payManager = new Part4.PayPalPaymentManager();
            var orderManager = new Part4.LocalOrderManager();

            var shop = new Part4.OnlineShop(invManager, orderManager, payManager);
            shop.Orders.Add(new Part4.OnlineOrder() { ProductName = "t-shirt", Price = 10.50M, Paid = false });
            shop.Orders.Add(new Part4.OnlineOrder() { ProductName = "jeans", Price = 30.99M, Paid = false });
            shop.Orders.Add(new Part4.OnlineOrder() { ProductName = "beanie", Price = 14.00M, Paid = true });

            shop.Run();
        }
    }
}
