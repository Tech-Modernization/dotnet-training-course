using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Helpers
{
    public class ConsoleHelper
    {
        public static bool GetInteger(string prompt, out int validatedInput, params IValidator[] validators)
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
    }
}
