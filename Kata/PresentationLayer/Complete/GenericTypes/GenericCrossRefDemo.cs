using System;
using System.Collections.Generic;
using Kata.CustomTypes;

namespace Kata.Demos
{
    public class GenericCrossRefDemo : DemoBase
    {

        public override void Run()
        {
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
                var invitedMessage = $"{who} was {(inviteState.HasValue ? "not " : "")}invited";
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

            var brandx = new CrossRef<string>("phil collins", "bill bruford");
            brandx.Band = "Brand X";
            var yes = new CrossRef<string>("bill bruford", "alan white");
            yes.Band = "Yes";
            var genesis = new CrossRef<string>("phil collins", "chester thompson");
            genesis.Band = "Genesis";
            var drummers = new List<string>() { "phil collins", "chester thompson", "alan white", "bill bruford" };
            var bands = new List<CrossRef<string>>() { brandx, yes, genesis };
            foreach (var d in drummers)
            {
                foreach (var b in bands)
                {
                    Console.WriteLine($"{d} did {(b.Find(d) ? "" : "not")} play drums in {b.Band}");
                }
            }
        }
    }

   

    
}
