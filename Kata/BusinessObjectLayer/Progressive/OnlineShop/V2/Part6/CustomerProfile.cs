namespace BusinessObjectLayer.Progressive.OnlineShop.V2.Part6
{
    // Responsibility: Encapsulating Customer Details
    public class CustomerProfile
    {
        public string Email { get; }
        public string Password { get; }
        public OnlineBasket SavedBasket { get; internal set; }

        public CustomerProfile(string email, string password)
        {
            Email = email;
            Password = password;
        }
    }
}