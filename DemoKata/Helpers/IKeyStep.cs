using System;

namespace Helpers
{
    public interface IKeyStep
    {
        int Index { get; }
        ConsoleKey Key { get; set; }
        string Prompt { get; }
        bool KeyValid<T1>(T1 selItem);
    }
}