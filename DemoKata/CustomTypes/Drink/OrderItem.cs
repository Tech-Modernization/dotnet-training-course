using System;
using System.Collections.Generic;
using System.Text;

namespace DemoKata.CustomTypes
{
    public class OrderItem
    {
        public DrinkBase Drink;
        public int Quantity;
        public decimal Subtotal;

        public OrderItem(DrinkBase drink)
        {
            Drink = drink;
        }

        public decimal CalcSubtotal()
        {
            Subtotal = Quantity * Drink.Price;
            return Subtotal;
        }
    }
}
