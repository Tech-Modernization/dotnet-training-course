using System;
using System.Collections.Generic;
using System.Linq;

namespace Helpers
{
    // resp: manage a step of the menu selection process
    public abstract class KeyStepBase
    {
        protected int Index { get; }

        protected string PromptFormat;
        public string Prompt => FormatPrompt();

        protected IMenu Menu { get; }

        protected Action<ConsoleKey, int> ConvertKeyToData;

        protected ConsoleKey Key;

        protected KeyStepBase(int index, string promptFormat, IMenu menu, Action<ConsoleKey, int> convertKeyToData)
        {
            Index = index;
            PromptFormat = promptFormat;
            Menu = menu;
            ConvertKeyToData = convertKeyToData;
        }

        public abstract ConsoleKey Ask();

        public void ConvertKeyToSelectionData()
        {
            ConvertKeyToData(Key, Index);
        }

        protected string FormatListExceptLast(List<string> list)
        {
            var copy = list.ToList();
            copy.Remove(copy.Last());
            return string.Join(", ", copy);
        }

        public abstract string FormatPrompt();
    }
}