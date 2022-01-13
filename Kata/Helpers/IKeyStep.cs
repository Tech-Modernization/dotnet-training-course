using System;

namespace Helpers
{
    public interface IKeyStep
    {
        public ConsoleKey Key { get; set; }
        public string Prompt { get; }
        public Action<ConsoleKey, MenuSelectionItem> Translate { get; }
    }
}