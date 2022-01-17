using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessObjectLayer.Progressive.OnlineShop.V2.Part5
{
    // resp: user interaction
    public interface IInteractor
    {
        string GetString(string prompt);
        ConsoleKey GetKey(string prompt, params ConsoleKey[] keyAllowed);
    }
}
