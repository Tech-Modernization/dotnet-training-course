using Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjectLayer.Progressive.OnlineShop.V2.Part6
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
            keyMap = new Dictionary<ConsoleKey, IPaymentMethod>();
            foreach(var pm in paymentMethods)
            {
                keyMap.Add((ConsoleKey) pm.Name[0], pm);
            }
        }

        public PaymentResult Pay(OnlineOrder order)
        {
            var payChoice = interactor.GetKey("Which payment method do you prefer?  [V,M]: ", GetKeyFlags.AddQuit, ConsoleKey.V, ConsoleKey.M);
            if (payChoice == ConsoleKey.Q) return PaymentResult.CustomerCancelled;

            var method = keyMap[payChoice];
            var cardNumber = string.Empty;
            var gotCardNo = interactor.GetString("Enter your card number: ", out cardNumber, new CustomValidator<string>(val => ((string)val).Length == 4));
            if (!gotCardNo) return PaymentResult.CustomerCancelled;

            var expiryDate = DateTime.MinValue;
            var expiryStr = interactor.GetString("Enter the expiry date: ");
            if (!DateTime.TryParse(expiryStr, out expiryDate))
            {
                return PaymentResult.CustomerCancelled;
            }

            if(!method.Authenticate(cardNumber, expiryDate))
            {
                return PaymentResult.CreditLimitExceeded;
            }

            if (!method.SendPayment(order.Total))
            {
                return PaymentResult.CreditLimitExceeded;
            }

            order.Paid = true;
            return PaymentResult.Success;
        }
    }
}
