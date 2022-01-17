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
            ConsoleKey k = default;
            string input = default;
            validatedInput = default;

            Console.Write(prompt);
            var getWithReadKey = validators.Any(v => v is KeyRangeValidator);
            if (getWithReadKey)
                k = Console.ReadKey().Key;
            else
            {
                input = Console.ReadLine();
                var isValidInt = int.TryParse(input, out validatedInput);
                if (!isValidInt) return false;
            }

            foreach (var v in validators)
            {
                if (v is KeyRangeValidator)
                {
                    if (((KeyRangeValidator) v).IsValid(k))
                    {
                        validatedInput = (int)k - 48;
                        continue;
                    }
                    return false;
                }

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

        public static ConsoleKey GetKey(string prompt, params ConsoleKey[] keysAllowed)
        {
            var keyList = keysAllowed.ToList();
            if (!keyList.Contains(ConsoleKey.Q)) keyList.Add(ConsoleKey.Q);
            ConsoleKey key = default;

            do
            {
                if (key != default)
                {
                    Console.WriteLine($"{key} is not a valid choice");
                }

                Console.Write(prompt);
                key = Console.ReadKey().Key;
                Console.WriteLine();
            }
            while (!keyList.Contains(key));

            return key;                        
        }
    }
}
