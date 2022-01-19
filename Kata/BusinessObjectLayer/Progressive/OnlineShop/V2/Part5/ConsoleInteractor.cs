using System;
using Helpers;

namespace BusinessObjectLayer.Progressive.OnlineShop.V2.Part5
{
    // resp: interacting thru the console
    public class ConsoleInteractor : IInteractor
    {
        public string GetString(string prompt)
        {
            return ConsoleHelper.GetString(prompt);
        }

        public ConsoleKey GetKey(string prompt, params ConsoleKey[] keysAllowed)
        {
            return ConsoleHelper.GetKey(prompt, keysAllowed);
        }

        public void Message(string msg)
        {
            Console.WriteLine(msg);
        }
    }
}