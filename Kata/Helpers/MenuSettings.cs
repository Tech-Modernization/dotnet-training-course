using System;
using System.Collections.Generic;
using System.Text;

namespace Kata.Helpers
{
    public class MenuSettings
    {
        public MenuFlags Flags;
        public bool SelectWithReadKey;
        public ConsoleKey ExitKey;
        public int DefaultOption;
        public bool GenerateExitOption;
        public string Prompt;
        public bool ClearScreenFirst;
        
        public MenuSettings(bool selectWithReadKey = false, 
            ConsoleKey exitKey = ConsoleKey.Escape,
            int defaultOption = 0, 
            bool generateExitOption = true, 
            string prompt = "Make your selection: > ",
            bool clearScreenFirst = true, 
            MenuFlags flags = MenuFlags.ClearScreenFirst | MenuFlags.GenerateExitOption)
        {
            SelectWithReadKey = selectWithReadKey;
            ExitKey = exitKey;
            DefaultOption = defaultOption;
            GenerateExitOption = generateExitOption;
            Prompt = prompt;
            ClearScreenFirst = clearScreenFirst;
            Flags = flags;
        }
    }

}
