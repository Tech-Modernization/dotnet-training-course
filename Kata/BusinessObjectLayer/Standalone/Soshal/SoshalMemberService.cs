using Helpers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BusinessObjectLayer.Soshal
{
    public class SoshalMemberService : IMemberService
    {
        private const string dbPath = "soshe.json";
        IJsonDataService dataService;
        private List<Member> Members;

        public SoshalMemberService(IJsonDataService dataService)
        {
            this.dataService = dataService;
            LoadDb();
        }

        public Member Login()
        {
            var username = ConsoleHelper.GetString("Username: ");
            var member = Members.SingleOrDefault(m => m.Email == username);
            if (member == null)
            {
                var yn = ConsoleHelper.GetKey("Oooh.  Looks like you're new.  Would you like to register, today?  [Y]es/[N]o: ", false, ConsoleKey.Y, ConsoleKey.N);
                if (yn == ConsoleKey.N)
                {
                    Console.WriteLine("Okay, maybe some other time :-)  Bye!");
                    return null;
                }

                member = Register(username);
            }

            return member;
        }

        private Member Register(string username)
        {
            var altUsername = string.Empty;
            var member = default(Member);
            while (member == null)
            {
                altUsername = ConsoleHelper.GetString($"Enter your preferred username or return to accept [{username}]: ");
                if (altUsername.Length == 0)
                {
                    altUsername = username;
                }

                member = Members.SingleOrDefault(m => m.Email == altUsername);
                if (member != null)
                {
                    Console.WriteLine("That username is taken.  You'll have to choose another.");
                    member = null;
                    continue;
                }

                member = EnterMemberDetails(altUsername);
                Members.Add(member);
                dataService.Save(new { Users = Members }, dbPath);
            }

            return member;
        }

        private void LoadDb()
        {
            var jsonObject = dataService.Load(dbPath);
            Members = jsonObject["Users"].ToObject<List<Member>>();
        }

        private Member EnterMemberDetails(string email)
        {
            var pwd = string.Empty;
            var pwdconf = string.Empty;
            var pwdMatch = false;

            while (!pwdMatch)
            {
                ConsoleHelper.GetString("Enter a password for your new account: ", out pwd);
                ConsoleHelper.GetString("Retype your password to confirm: ", out pwdconf);

                pwdMatch = pwd == pwdconf;
                if (!pwdMatch)
                {
                    Console.WriteLine("The confirmation password has to match the original");
                    continue;
                }
            }

            string name;
            ConsoleHelper.GetString("Enter your real name: ", out name);
            string birthday;
            var dt = DateTime.MinValue;

            while (!ConsoleHelper.GetString("When's your birthday? : ", out birthday, new CustomValidator<string>(dobString =>
            {
                var dtOkay = DateTime.TryParse((string)dobString, out dt);
                if (dtOkay)
                {
                    var now = DateTime.Now;
                    return ((int)now.Subtract(dt).TotalDays / 365 >= 18);
                }
                return false;
            })))
            {
                Console.WriteLine("You must be over 18 to use this social network");
            }

            return new Member(name, email, pwd, dt);
        }
    }
}