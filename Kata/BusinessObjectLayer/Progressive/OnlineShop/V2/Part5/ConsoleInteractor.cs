using System;
using Helpers;

namespace BusinessObjectLayer.Progressive.OnlineShop.V2.Part5
{
    // resp: interacting thru the console
    public class ConsoleInteractor : IInteractor
    {
        public bool GetString(string prompt, out string validatedString, params IValidator<string>[] validators)
        {
            return ConsoleHelper.GetString(prompt, out validatedString, validators);
        }
        public string GetString(string prompt)
        {
            return ConsoleHelper.GetString(prompt);
        }

        public ConsoleKey GetKey(string prompt, params ConsoleKey[] keysAllowed)
        {
            return GetKey(prompt, true, false, keysAllowed);
        }

        public void Message(string msg)
        {
            Console.WriteLine(msg);
        }

        public int GetInteger(string prompt, Func<ConsoleKey> preEntryStep, 
            out ConsoleKey terminator, params IValidator<int>[] validators)
        {
            terminator = preEntryStep();
            if (!char.IsDigit((char)terminator))
            {
                return -1;
            }

            var inInt = 0;
            var gotInt = ConsoleHelper.GetInteger("", $"{(char)terminator}", out inInt, validators);
            return gotInt ? inInt : -1;
        }

        public ConsoleKey GetKey(string prompt, bool addQuit, bool noNewLine, params ConsoleKey[] keysAllowed)
        {
            return ConsoleHelper.GetKey(prompt, addQuit, noNewLine, keysAllowed);
        }
        public ConsoleKey GetKey(string prompt, bool addQuit, params ConsoleKey[] keysAllowed)
        {
            return ConsoleHelper.GetKey(prompt, addQuit, false, keysAllowed);
        }
    }
}