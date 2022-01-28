using System;
using System.Collections.Generic;
using System.Linq;
using Helpers;

namespace BusinessObjectLayer.Progressive.OnlineShop.V2.Part7
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

        public ConsoleKey GetKey(string prompt, GetKeyFlags flags = GetKeyFlags.AddQuit | GetKeyFlags.NoNewLine, params ConsoleKey[] keysAllowed)
        {
            return ConsoleHelper.GetKey(prompt, flags, keysAllowed);
        }

        public ConsoleKey GetKey<T>(string prompt, List<T> options, Func<T, string> getOptionText, out Dictionary<ConsoleKey, T> result)
        {
            var dic = new Dictionary<ConsoleKey, string>();
      
            var key = ConsoleHelper.GetKey(prompt, options.Select(o => getOptionText(o)).ToList(), out dic);

            var _result = new Dictionary<ConsoleKey, T>();
            foreach (var kvp in dic)
            {
                _result.TryAdd(kvp.Key, options.SingleOrDefault(opt => getOptionText(opt).Collapse() == kvp.Value.Collapse()));
            }

            result = _result;
            return key;
        }
    }
}