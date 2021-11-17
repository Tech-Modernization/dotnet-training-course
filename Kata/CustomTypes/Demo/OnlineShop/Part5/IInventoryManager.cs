using System;
using System.Collections.Generic;
using System.Text;

namespace Kata.CustomTypes.OnlineShop.Part5
{
    public interface IInventoryManager
    {
        void Load();
        List<Product> Get();
    }
}
