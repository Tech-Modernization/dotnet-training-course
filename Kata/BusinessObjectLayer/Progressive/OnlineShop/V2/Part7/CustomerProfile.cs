namespace BusinessObjectLayer.Progressive.OnlineShop.V2.Part7
{
    // Responsibility: Encapsulating Customer Details
    public class CustomerProfile
    {
        public string Name { get; }
        public bool IsNew { get; internal set; }
        public OnlineBasket SavedBasket { get; internal set; }

        public CustomerProfile(string name)
        {
            Name = name;
            IsNew = true;
        }
    }
}