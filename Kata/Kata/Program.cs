using System;
using System.Collections.Generic;
using Kata.Demos;
using Kata.Helpers;

namespace Kata
{
    public class Program
    {
        static void Main(string[] args)
        {
            IDemo demoInstance = default;
            var mainMenu = new MenuHelper();
            mainMenu.Init(() => new List<string> { "Demos", "Classes", "Interfaces"});
            var exit = false;
            do
            {
                var selectedDemo = mainMenu.SelectFromMenu("> ");
                switch (selectedDemo)
                {
                    case 1:
                        demoMenu();
                        continue;
                    case 2:
                        classMenu();
                        continue;
                    case 3:
                        ifaceMenu();
                        continue;
                    default:
                        exit = true;
                        break;
                }
            }
            while (!exit);
        }
        static void demoMenu()
        {
            var demoMenu = new MenuHelper();
            demoMenu.Init(TypeHelper.ImplementersOf<IDemo>);
            var keystroke = default(ConsoleKey);
            do
            {
                demoMenu.SelectFromMenu("> ", type =>
                {
                    var inst = Activator.CreateInstance(typeof(IDemo).Assembly.FullName, type.Text);
                    var demo = inst.Unwrap() as IDemo;
                    demo?.Run();
                });
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