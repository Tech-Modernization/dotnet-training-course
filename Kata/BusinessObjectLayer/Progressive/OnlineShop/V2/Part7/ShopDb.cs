using System.Collections.Generic;

namespace BusinessObjectLayer.Progressive.OnlineShop.V2.Part7
{
    // Resp: encapulate all customer and related data
    public class ShopDb
    {
        public List<CustomerProfile> Customers { get; }
        public List<Product> Products { get; }
        public ShopDb(List<CustomerProfile> customers, List<Product> products)
        {
            Customers = customers;
            Products = products;
        }
    }
}