using System;
using System.Collections.Generic;
using System.Linq;

namespace Helpers
{
    // resp: manage a step of the menu selection process
    public abstract class KeyStepBase
    {
        protected int Index { get; }

        private string promptFormat;
        public string Prompt => promptFormat;

        protected IMenu Menu { get; }

        protected Action<ConsoleKey, int> ConvertKeyToData;

        protected ConsoleKey Key;

        protected KeyStepBase(int index, string promptFormat, IMenu menu, Action<ConsoleKey, int> convertKeyToData)
        {
            Index = index;
            this.promptFormat = promptFormat;
            Menu = menu;
            ConvertKeyToData = convertKeyToData;
        }

        public ConsoleKey Ask()
        {
            var keysAllowed = new List<ConsoleKey>() { ConsoleKey.B, ConsoleKey.W, ConsoleKey.S };
            Key = ConsoleHelper.GetKey(Prompt, keysAllowed.ToArray());
            return Key;
        }

        public void ConvertKeyToSelectionData()
        {
            // ConvertKeyToData(Key, Index);
            Console.WriteLine($"Converting {Key} to data...");
        }
    }
}