using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Helpers
{
    public static class ConsoleHelper
    {
        public static bool GetInteger(string prompt, out int validatedInput, params IValidator<int>[] validators)
        {
            return GetInteger(prompt, null, out validatedInput, validators);
        }
        public static bool GetInteger(string prompt, string initialValue, out int validatedInput, params IValidator<int>[] validators)
        {
            string input = default;
            validatedInput = default;

            Console.Write(prompt);
            input = string.IsNullOrEmpty(initialValue)
                ? Console.ReadLine()
                : $"{initialValue}{Console.ReadLine()}";

            var isValidInt = int.TryParse(input, out validatedInput);
            if (!isValidInt) return false;

            foreach (var v in validators)
            {
                if (!v.IsValid(validatedInput))
                    return false;
            }

            return true;
        }

        public static string GetString(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine();
        }
        public static bool GetString(string prompt, out string validatedInput, params IValidator<string>[] validators)
        {
            do
            {
                validatedInput = GetString(prompt);
            }
            while (validatedInput.Trim().Length == 0);

            foreach(var v in validators)
            {
                if (!v.IsValid(validatedInput))
                    return false;
            }

            return true;
        }

        public static ConsoleKey GetKey(string prompt, GetKeyFlags flags = GetKeyFlags.AddQuit | GetKeyFlags.NoNewLine, params ConsoleKey[] keysAllowed )
        {
            var addQuit = flags.HasFlag(GetKeyFlags.AddQuit);
            var noNewLine = flags.HasFlag(GetKeyFlags.NoNewLine);
            
            if (flags.HasFlag(GetKeyFlags.YesNo))
            {
                keysAllowed = new ConsoleKey[] { ConsoleKey.Y, ConsoleKey.N };
            }

            return GetKey(prompt, addQuit, noNewLine, keysAllowed);
        }

        public static ConsoleKey GetKey(string prompt, bool addQuit, params ConsoleKey[] keysAllowed)
        {
            return GetKey(prompt, addQuit, false, keysAllowed);
        }
        public static ConsoleKey GetKey(string prompt, bool addQuit, bool noNewLine, params ConsoleKey[] keysAllowed)
        {
            var keyList = keysAllowed.ToList();
            if (!keyList.Contains(ConsoleKey.Q) && addQuit)
            {
                keyList.Add(ConsoleKey.Q);
            }
            ConsoleKey key = default;

            do
            {
                if (key != default)
                {
                    Console.WriteLine($"{key} is not a valid choice");
                }

                Console.Write(prompt);
                key = Console.ReadKey().Key;
                if (!noNewLine) Console.WriteLine();
            }
            while (!keyList.Contains(key));

            return key;
        }
        public static ConsoleKey GetKey(string prompt, params ConsoleKey[] keysAllowed)
        {
            return GetKey(prompt, true, keysAllowed);
        }
    }
}
