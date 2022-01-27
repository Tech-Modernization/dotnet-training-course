using Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjectLayer.Progressive.OnlineShop.V2.Part7
{
    // resp: manage local payments
    public class PaymentManager : IPaymentManager
    {
        IInteractor interactor;
        List<IPaymentMethod> paymentMethods;
        Dictionary<ConsoleKey, IPaymentMethod> keyMap;

        public PaymentManager(IInteractor interactor, List<IPaymentMethod> paymentMethods)
        {
            this.interactor = interactor;
            this.paymentMethods = paymentMethods;
        }

        public PaymentResult ProcessPayment(CustomerProfile customer, OnlineOrder order)
        {
            var keyMap = new Dictionary<ConsoleKey, IPaymentMethod>();
            var payChoice = interactor.GetKey("How would you like to pay? (#options) : ", paymentMethods, p => p.Name, out keyMap);
            if (payChoice == ConsoleKey.Q) return PaymentResult.CustomerCancelled;

            var method = this.keyMap[payChoice];

            return method.ProcessPayment(customer, order);

        }
    }
}
