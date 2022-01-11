using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using BusinessObjectLayer.Recipe.Part12;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace PresentationLayer
{
    public class JsonDemo : DemoBase
    {
        public SosheDb soshedb;
        public class SosheDb
        {
            public List<SosheUser> Users;
        }

        public class SosheUser
        {
            public string Name;
            public DateTime Birthday;
            public string Email;
            public List<SosheGroup> Groups = new List<SosheGroup>();

            public bool IsNew = true;
        }
        public class SosheGroup
        {
            public string Name;
        }

        public class Age
        {
            public int currentAge;
        }
        public class Person
        {
            public string firstname;
            public string surname;
            public List<string> address;
            public Age age;
           // public Level1 level1;
        }
        public override void Run()
        {
            //            AddPart(Part2, "Setup initial Soshe db");
            AddPart(Part3, "Login / Sign up to soshe");

            base.Run();
        }

        public bool SaveDb()
        {
            try
            {
                var jsonText = JsonConvert.SerializeObject(soshedb);
                File.WriteAllText("../../../soshe.json", jsonText);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<SosheUser> GetUsers()
        {
            var jsonText = File.ReadAllText("soshe.json");
            var jobject = JObject.Parse(jsonText);
            soshedb = jobject.ToObject<SosheDb>();
            return soshedb.Users;
        }

        public void Part3()
        {
            var users = GetUsers();

            do
            {
                foreach (var user in users)
                {
                    Console.WriteLine($"{(user.IsNew ? "*" : "")}username: {user.Name}\nbirthday:{user.Birthday:dd/MMM}\nemail:{user.Email}");
                    Console.WriteLine($"{user.Name} is a member of: {string.Join(", ", user.Groups.Select(g => g.Name).ToList())}");
                }

                var u = Login();
                Console.WriteLine($"Logged in {(u.IsNew ? "new" : "")} user: {u.Name}");
            }
            while (Console.ReadKey().Key != ConsoleKey.X);

            if (SaveDb())
            {
                Console.WriteLine("Wrote changes successfully");
            }
        }

        public SosheUser SignUp(string notFoundUser)
        {
            var user = new SosheUser();
            
            Console.Write($"Username [{notFoundUser}]: ");
            var username = Console.ReadLine();
            if (string.IsNullOrEmpty(username)) username = notFoundUser;

            Console.Write("Birthday: ");
            var birthday = Console.ReadLine();
            Console.Write("Email: ");
            var email = Console.ReadLine();

            do
            {
                Console.Write($"Group: ");
                var group = Console.ReadLine();
                if (group == "") break;
                user.Groups.Add(new SosheGroup() { Name = group });
                Console.WriteLine("[X=exit, or any to add another]");
            }
            while (Console.ReadKey().Key != ConsoleKey.X);

            user.Name = username;
            user.Email = email;
            if (DateTime.TryParse(birthday, out user.Birthday))
            {
                soshedb.Users.Add(user);
                return user;
            }
            return null;
        }

        public SosheUser GetUser(string username)
        {
            return soshedb.Users.SingleOrDefault(user => user.Name == username);
        }

        public SosheUser Login()
        {
            do
            {
                Console.Write("Username: ");
                var username = Console.ReadLine();
                var user = GetUser(username);
                if (user != null)
                {
                    user.IsNew = false;
                    return user;
                }

                return SignUp(username);
            }
            while (true);
        }
        public void Part2()
        {
            var users = new List<SosheUser>();
            do
            {
                Console.WriteLine("");
                var user = new SosheUser();
                Console.Write("Username: ");
                var username = Console.ReadLine();
                Console.Write("Birthday: ");
                var birthday = Console.ReadLine();
                Console.Write("Email: ");
                var email = Console.ReadLine();

                do
                {
                    Console.WriteLine("");
                    Console.Write($"Group: ");
                    var group = Console.ReadLine();
                    user.Groups.Add(new SosheGroup() { Name = group });
                    Console.WriteLine("[X=exit, or any to add another]");
                }
                while (Console.ReadKey().Key != ConsoleKey.X);

                user.Name = username;
                user.Email = email;
                if (DateTime.TryParse(birthday, out user.Birthday))
                {
                    users.Add(user);
                }

                Console.WriteLine("[X=exit, or any to add another]");
            }
            while (Console.ReadKey().Key != ConsoleKey.X);

        }
        public void Part1()
        {
            var textArray = File.ReadAllText("sampleArray.json");
            var textObject = File.ReadAllText("sampleObject.json");

            var jsonArray = JsonConvert.DeserializeObject<List<Person>>(textArray);

            var jsonObject = JObject.Parse(textObject);

            var ingList = new List<Ingredient>();
            var ingredDb = JsonConvert.DeserializeObject<Dictionary<string, string>>(File.ReadAllText("ingredients.json"));

            foreach (var kvp in ingredDb)
            {
                ingList.Add(new Ingredient(kvp.Key, kvp.Value));
            }

            foreach (var i in ingList)
                dbg(i);
        }
    }
}
