using System;
using System.Collections.Generic;
using System.Text;

using Kata.CustomTypes;

namespace Kata.Demos
{
    public class IntroToGenerics_CrossRef : DemoBase
    { 
        public override void Run()
        {
            AddPart(Part1, "Cross-reference two lists of int");
            AddPart(Part2, "Cross-reference two lists of decimal");
            AddPart(Part3, "Cross-ref two lists of string");
            base.Run();
        }
        public void Part1()
        {
            var intRef = new CrossRef<int>(1, 2, 3, 6, 77, 54, 56, 567, 4, 64);
            Console.WriteLine($"intRef {(intRef.Find(66) ? "contains" : "does not contain")} 66");
            Console.WriteLine($"intRef {(intRef.Find(77) ? "contains" : "does not contain")} 77");
        }
        public void Part2()
        {

            var decRef = new CrossRef<decimal>(1.1M, 2.2M, 3.3M, 4.4M);
            Console.WriteLine($"decRef {(decRef.Find(2.2M) ? "contains" : "does not contain")} 2.2");
            Console.WriteLine($"decRef {(decRef.Find(22.22M) ? "contains" : "does not contain")} 22.22");

        }
        public void Part3()
        {
            var invited = new CrossRef<string>("alan", "dave", "steve", "petunia", "sally", "jenny", "milos", "sheherezade");
            var replied = new CrossRef<string>("alan", "dave", "sally", "milos", "sheherezade");

            do
            {
                Console.Write("Who's coming? : ");
                var who = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(who))
                    break;

                var wasInvited = invited.Find(who);
                var hasReplied = replied.Find(who);
                var message = $"{who} was {(wasInvited ? "" : "not ")}invited";
                var rsvpMessage = wasInvited ? $" {(hasReplied ? "and has RSVP'd" : "but has not yet RSVP'd")}" : "";
                Console.WriteLine($"{message}{rsvpMessage}");
            }
            while (true);

        }
    }

    
}
