namespace BusinessObjectLayer.Progressive.OnlineShop.V2.Part7
{
    public interface ICustomerService
    {
        CustomerProfile EstablishCustomerContext(CustomerDecision decision);
        void SaveBasket(OnlineBasket basket, CustomerProfile customer = null);
        CustomerProfile Login();
        void Manage();
    }
}