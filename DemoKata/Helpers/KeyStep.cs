using System;
using System.Collections.Generic;
using System.Linq;

namespace Helpers
{
    public abstract class KeyStep
    {
        public int Index { get; }
        protected List<ConsoleKey> keys = new List<ConsoleKey>();
        protected string KeyString => string.Join("", keys.Select(k => (char)k));
        public ConsoleKey Key { get => keys.Last(); set => keys.Add(value); }
        protected string prompt;
        public abstract string Prompt { get; }
        protected KeyStep(int index, string prompt)
        {
            Index = index;
            this.prompt = prompt;
        }
        public abstract void SetSelectionItem<T>(T selItem);
        public abstract bool KeyValid();
    }
}