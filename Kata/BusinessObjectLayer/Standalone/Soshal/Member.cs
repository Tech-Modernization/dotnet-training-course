using System;

namespace BusinessObjectLayer.Soshal
{
    public class Member
    {
        public string Name { get; }
        public string Email { get; }
        public string Password { get; } 
        public DateTime Birthday { get; }
        public Member(string name, string email, string password, DateTime birthday)
        {
            Name = name;
            Email = email;
            Password = password;
            Birthday = birthday;
        }
    }
}