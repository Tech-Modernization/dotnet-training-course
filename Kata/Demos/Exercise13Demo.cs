using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/*
part 1:

define a class CrossRef<T>

declare a private of List of T in the class 

write a constructor accepting a params T[] that adds everything passed in to the list.

write a method Find accepting T as a parameter and returning bool.

the Find method uses the List.Contains method to determine if the parameter is in the list.

declare instances for int, decimal and string and test your class.

part 2:

declare 2 CrossRef<string> instances for party invitations.  one is invites sent, the other is rvsps.

write a loop to get input from the console and then depending on what matches are made write on of these messages to the screen.

- "name" was not invited
- "name" was invited but has not RSVP'd
- "name" was invited and has RSVP'd

part 3:

define a class RSVP inheriting from CrossRef<string> 

add a private Dictionary<string, bool> responses

call the base constructor with the list of names passed in.

in the RVSP constructor, add the same names to the responses dictionary, choosing true or false at random for the bool value.

add a method WillBeAttending returning a nullable bool, accepting a string to lookup in the dictionary and return the value for the key.

update your program to use the new class and output one of the following messages for each name entered.

- "name" was not invited
- "name" was invited but has not RSVP'd
- "name" was invited and sends their apologies
- YAY! "name" SAYS THEY'RE COMING TO YOUR PARTY!

part 4:

add an overload for WillBeAttending with an out bool parameter "invited".

set invited to true or false based on calling Find on the parent class.

don't lookup the name in the dictionary if Find returns false.

update your program to achieve the same result using only the RSVP class.

-------------------------

*********** SOLUTION FOLLOWS *****************

//// PUT THIS IN YOUR MAIN  or Run method...

            var intRef = new CrossRef<int>(1, 2, 3, 6, 77, 54, 56, 567, 4, 64);
            Console.WriteLine($"intRef {(intRef.Find(66) ? "contains" : "does not contain")} 66");
            Console.WriteLine($"intRef {(intRef.Find(77) ? "contains" : "does not contain")} 77");

            var decRef = new CrossRef<decimal>(1.1M, 2.2M, 3.3M, 4.4M);
            Console.WriteLine($"decRef {(decRef.Find(2.2M) ? "contains" : "does not contain")} 2.2");
            Console.WriteLine($"decRef {(decRef.Find(22.22M) ? "contains" : "does not contain")} 22.22");

            var invited = new CrossRef<string>("alan", "dave", "steve", "petunia", "sally", "jenny", "milos", "sheherezade");
            var replied = new CrossRef<string>("alan", "dave", "sally", "milos", "sheherezade");

            do
            {
                Console.Write("Who's coming? : ");
                var who = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(who)) break;

                var wasInvited = invited.Find(who);
                var hasReplied = replied.Find(who);
                var message = $"{who} was {(wasInvited ? "" : "not ")}invited";
                var rsvpMessage = wasInvited ? $" {(hasReplied ? "and has RSVP'd" : "but has not yet RSVP'd")}" : "";
                Console.WriteLine($"{message}{rsvpMessage}");
            }
            while (true);

            var rsvp = new RSVP("alan", "dave", "steve", "petunia", "sally", "jenny", "milos", "sheherezade");
            do
            {
                Console.Write("Who's coming? : ");
                var who = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(who)) break;

                var inviteState = rsvp.WillBeAttending(who);
                var invitedMessage =  $"{who} was {(inviteState.HasValue ? "not ": "")}invited";
                var rsvpMessage = inviteState.HasValue
                    ? $"{(inviteState.Value ? $"YAY!  {who}'s coming to your party!" : $"{who} sends their apologies")}"
                    : invitedMessage;

                Console.WriteLine(inviteState.HasValue ? rsvpMessage : invitedMessage);

                bool wasInvited;
                inviteState = rsvp.WillBeAttending(who, out wasInvited);
                invitedMessage = $"{who} was {(wasInvited ? "" : "not ")}invited";
                rsvpMessage = inviteState.HasValue
                    ? $"{(inviteState.Value ? $"YAY!  {who}'s coming to your party!" : $"{who} sends their apologies")}"
                    : $"{who} has not sent an RSVP";

                Console.WriteLine(wasInvited ? rsvpMessage : invitedMessage);
            }
            while (true);
                        
        -------------------
        
        
    public class CrossRef<T>
    {
        private List<T> items;
        public string Band;
        public CrossRef(params T[] items)
        {
            this.items = new List<T>(items);
        }

        public bool Find(T item)
        {
            return items.Contains(item);
        }
    }

    public class RSVP : CrossRef<string>
    {
        private Dictionary<string, bool> responses = new Dictionary<string, bool>();

        public RSVP(params string[] names) : base(names)
        {
            foreach(var n in names)
            {
                if (n[0] % 2 == 1)
                {
                    Console.WriteLine($"Adding response from {n}");
                    responses.TryAdd(n, n.ToCharArray().Sum(c => c) % 2 == 0);
                    Console.WriteLine($"{n}'s {(responses[n] ? "" : "not ")} coming");
                }
            }
        }

        public bool? WillBeAttending(string name)
        {
            return responses.ContainsKey(name) ? responses[name] : false;
        }
        public bool? WillBeAttending(string name, out bool invited)
        {
            invited = Find(name);
            bool? retval = null;
            return invited ? responses.ContainsKey(name) ? responses[name] : retval : false;
        }
    }
*/
namespace Kata.Demos
{
    public class Exercise13Demo : DemoBase
    {
        public void Run()
        {
            var invited = new CrossRef<string>("alan", "dave", "steve", "petunia", "sally", "jenny", "milos", "sheherezade");
            var replied = new CrossRef<string>("alan", "dave", "sally", "milos", "sheherezade");

            do
            {
                break;
                Console.Write("Who's coming? : ");
                var who = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(who)) break;

                var wasInvited = invited.Find(who);
                var hasReplied = replied.Find(who);
                var message = $"{who} was {(wasInvited ? "" : "not ")}invited";
                var rsvpMessage = wasInvited ? $" {(hasReplied ? "and has RSVP'd" : "but has not yet RSVP'd")}" : "";
                Console.WriteLine($"{message}{rsvpMessage}");
            }
            while (true);


            var rsvp = new RSVP("alan", "dave", "steve", "petunia", "sally", "jenny", "milos", "sheherezade");
            do
            {
                Console.Write("Who's coming? : ");
                var who = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(who)) break;

             
                bool wasInvited;
                var inviteState = rsvp.WillBeAttending(who, out wasInvited);
                var invitedMessage = $"{who} was {(wasInvited ? "" : "not")} invited";
                var rsvpMessage = inviteState.HasValue
                    ? $"{(inviteState.Value ? $"YAY!  {who}'s coming to your party!" : $"{who} sends their apologies")}"
                    : $"{who} has not sent an RSVP";

                Console.WriteLine(wasInvited ? rsvpMessage : invitedMessage);
            }
            while (true);

        }
        public void RunPart1()
        {
            var intList = new CrossRef<int>(22, 33, 44, 55);
            var decList = new CrossRef<decimal>(1.2M, 2.3M, 3.4M, 4.5M);
            var strList = new CrossRef<string>("dozy", "beeaky", "mick", "titch");

            Console.WriteLine($"intList {(intList.Find(11) ? "contains" : "does not contain")} 11");
            Console.WriteLine($"intList {(intList.Find(44) ? "contains" : "does not contain")} 44");
            Console.WriteLine($"decList {(decList.Find(1.1M) ? "contains" : "does not contain")} 1.1");
            Console.WriteLine($"decList {(decList.Find(3.4M) ? "contains" : "does not contain")} 3.4");
            Console.WriteLine($"strList {(strList.Find("noddy") ? "contains" : "does not contain")} noddy");
            Console.WriteLine($"strList {(strList.Find("titch") ? "contains" : "does not contain")} titch");
        }


        public class CrossRef<T>
        {
            private List<T> items;

            public CrossRef(params T[] argItems)
            {
                items = new List<T>(argItems);
            }

            public bool Find(T item)
            {
                return items.Contains(item);
            }
        }

        public class RSVP : CrossRef<string>
        {
            private Dictionary<string, bool> responses = new Dictionary<string, bool>();

            public RSVP(params string[] names) : base(names)
            {
                foreach (var n in names)
                {
                    if (n[0] % 2 == 1)
                    {
                        Console.WriteLine($"Adding response from {n}");
                        responses.TryAdd(n, n.ToCharArray().Sum(c => c) % 2 == 0);
                        Console.WriteLine($"{n}'s {(responses[n] ? "" : "not ")} coming");
                    }
                }
            }
            public bool? WillBeAttending(string name)
            {
                bool? nullBool = null;
                return responses.ContainsKey(name) ? responses[name] : nullBool;
            }
            public bool? WillBeAttending(string name, out bool invited)
            {
                invited = Find(name);
                bool? retval = null;
                return invited ? responses.ContainsKey(name) ? responses[name] : retval : false;
            }

        }
    }
}
