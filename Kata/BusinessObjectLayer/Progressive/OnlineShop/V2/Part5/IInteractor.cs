using Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessObjectLayer.Progressive.OnlineShop.V2.Part5
{
    // resp: user interaction
    public interface IInteractor
    {
        string GetString(string prompt);
        bool GetString(string prompt, out string validatedString, params IValidator<string>[] validators);
        ConsoleKey GetKey(string prompt, GetKeyFlags flags = GetKeyFlags.AddQuit | GetKeyFlags.NoNewLine, params ConsoleKey[] keysAllowed);
        ConsoleKey GetKey(string prompt, bool addQuit, bool noNewLine, params ConsoleKey[] keysAllowed);
        ConsoleKey GetKey(string prompt, bool addQuit, params ConsoleKey[] keysAllowed);
        ConsoleKey GetKey(string prompt, params ConsoleKey[] keysAllowed);
        void Message(string msg);

        int GetInteger(string prompt, Func<ConsoleKey> preEntryStep,
            out ConsoleKey terminator, params IValidator<int>[] validators);
    }
}
