namespace BusinessObjectLayer.Progressive.OnlineShop.V2.Part4
{
    public class LocalSecurityManager : ISecurityManager
    {
        public CustomerProfile Login()
        {
            return new CustomerProfile("pd@mailinator.com", "swordfish");
        }
    }
}