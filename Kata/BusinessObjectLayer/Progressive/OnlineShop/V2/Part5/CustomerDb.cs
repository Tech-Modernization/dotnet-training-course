using System.Collections.Generic;

namespace BusinessObjectLayer.Progressive.OnlineShop.V2.Part5
{
    // Resp: encapulate all customer and related data
    public class CustomerDb
    {
        public List<CustomerProfile> Customers { get; }
        public CustomerDb()
        {
            Customers = new List<CustomerProfile>();
        }
    }
}