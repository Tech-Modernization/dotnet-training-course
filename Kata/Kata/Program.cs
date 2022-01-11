using System;
using Helpers;
using PresentationLayer;

namespace Kata
{
    public class Program
    {

        static void Main(string[] args)
        {
            runMenu(typeof(IDemo));
        }
        static void runMenu(Type sourceType)
        {
            var thisMenu = new MenuHelper();
            if (sourceType.IsInterface)
                thisMenu.Build(() => MenuHelper.GetTypedMenuItems(TypeHelper.ImplementersOf(sourceType)), t => runMenu(t));
            else if (sourceType.IsAbstract)
                thisMenu.Build(() => MenuHelper.GetTypedMenuItems(TypeHelper.ChildrenOf(sourceType)), t => runMenu(t));
            else
            {
                var inst = sourceType.Assembly.CreateInstance(sourceType.FullName);
                sourceType.GetMethod("Run").Invoke(inst, null);
                return;
            }

            var keystroke = default(ConsoleKey);
            do
            {
                var selection = thisMenu.SelectFromMenu();
                if (selection == thisMenu.Settings.ExitOption)
                    break;

                keystroke = Console.ReadKey().Key;
            }
            while (keystroke != ConsoleKey.Escape);
        }

        static void classMenu()
        { }
        static void ifaceMenu()
        { }
    }
}