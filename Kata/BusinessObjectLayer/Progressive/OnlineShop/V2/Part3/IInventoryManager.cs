using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessObjectLayer.Progressive.OnlineShop.V2
{
    public interface IInventoryManager
    {
        List<Product> Search(string searchText);
    }
}
