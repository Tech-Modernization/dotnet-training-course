using System;

namespace Helpers
{
    public abstract class MenuSelectionItem 
    {
        public int Index { get; }
        public string Text { get; }
        public MenuSelectionItem(int index, string text)
        {
            Index = index;
            Text = text;
        }

        public abstract bool KeyToData(KeyStep step);
    }
}