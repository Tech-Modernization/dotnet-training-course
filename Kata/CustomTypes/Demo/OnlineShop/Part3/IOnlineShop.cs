using System;
using System.Collections.Generic;
using System.Text;

namespace Kata.CustomTypes.OnlineShop.Part3
{
    public interface IOnlineShop
    {
        void LoadInventory();
        void CreateOrder();
        void TakePayment();
    }
}
