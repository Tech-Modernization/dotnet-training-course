﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Kata.CustomTypes.Bartender
{
    public interface IPaymentProcessor
    {
        PaymentMethod GetPaymentMethod(Customer cust);
        PaymentResult TakePayment(Payment payment, Customer cust);
    }
}
