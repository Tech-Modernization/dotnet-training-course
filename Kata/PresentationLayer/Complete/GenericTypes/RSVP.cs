using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjectLayer
{
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
            return responses.ContainsKey(name) ? responses[name] : false;
        }
        public bool? WillBeAttending(string name, out bool invited)
        {
            invited = Find(name);
            bool? retval = null;
            return invited ? responses.ContainsKey(name) ? responses[name] : retval : false;
        }
    }
}
