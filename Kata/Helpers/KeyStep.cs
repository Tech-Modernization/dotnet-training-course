using System;

namespace Helpers
{
    public class KeyStep<TResult>
    {
        public ConsoleKey Key;
        public string Prompt;
        public TResult Response;
        public Func<ConsoleKey, TResult> Translate;
    }
}