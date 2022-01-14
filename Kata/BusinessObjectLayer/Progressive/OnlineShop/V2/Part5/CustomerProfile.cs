﻿namespace BusinessObjectLayer.Progressive.OnlineShop.V2.Part5
{
    // Responsibility: Encapsulating Customer Details
    public class CustomerProfile
    {
        public string Email { get; }
        public string Password { get; }
        public CustomerProfile(string email, string password)
        {
            Email = email;
            Password = password;
        }
    }
}