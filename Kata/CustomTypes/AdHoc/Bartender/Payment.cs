using System;
using System.Collections.Generic;
using System.Text;

namespace Kata.CustomTypes.Bartender
{
    public class Payment
    {
        public decimal AmountDue { get; }
        public decimal AmountTendered { get; set; }
        public decimal ChangeDue { get; set; }
        public bool ChangeAccepted { get; set; }
        public PaymentMethod Method { get; set; }
        public Payment(decimal amountDue)
        {
            AmountDue = amountDue;
        }

        public bool CalculateChange()
        {
            ChangeDue = AmountTendered - AmountDue;
            return (ChangeDue >= 0);
        }
    }
}
