using Helpers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BusinessObjectLayer.Bartender
{
    public class BarKeyStep : KeyStepBase
    {
        public BarKeyStep(int index, string promptFormat, IMenu menu, Action<ConsoleKey, int> convertKeyToData) : base(index, promptFormat, menu, convertKeyToData)
        {
        }

        public override string FormatPrompt()
        {
            object[] formatArgs = default;
            var barSelItem = Menu.SelectionItem as BarSelectionItem;
            switch(Index)
            {
                case 1:
                    formatArgs = new object[] { FormatListExceptLast(Menu.ItemNames), Menu.ItemNames.Last() };
                    break;
                case 2:
                    formatArgs = new object[] 
                    { 
                        barSelItem.Stock.Name, 
                        FormatListExceptLast(barSelItem.Stock.Measures.Select(m => m.ToString()).ToList()), 
                        barSelItem.Stock.Measures.Last() 
                    };
                    break;
                case 3:
                    formatArgs = new object[] { barSelItem.Measure, barSelItem.Stock.Name };
                    break;
            }

            return string.Format(PromptFormat, formatArgs);
        }

        public override ConsoleKey Ask()
        {
            ConsoleKey[] keysAllowed = default;
            var barSelItem = Menu.SelectionItem as BarSelectionItem;

            switch (Index)
            {
                case 1:
                    keysAllowed = Menu.ItemNames.Select(name => (ConsoleKey)name[0]).ToArray();
                    break;
                case 2:
                    keysAllowed = barSelItem.Stock.Measures.Select(name => (ConsoleKey)name.ToString()[0]).ToArray();
                    break;
                case 3:
                    // var numbers = "123456789";
                    // numbers.Select(c => (ConsoleKey)c).ToArray();
                    keysAllowed = "12345679".Select(c => (ConsoleKey)c).ToArray();
                    break;
            }
            Key = ConsoleHelper.GetKey(Prompt, keysAllowed);
            return Key;
        }
    }
}
