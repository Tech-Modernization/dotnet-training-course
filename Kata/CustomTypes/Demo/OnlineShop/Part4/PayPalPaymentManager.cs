﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Kata.CustomTypes.OnlineShop.Part4
{
    public class PayPalPaymentManager : IPaymentManager
    {

        public void TakePayment()
        {
            Console.WriteLine("Taking a payment");
        }
    }
}