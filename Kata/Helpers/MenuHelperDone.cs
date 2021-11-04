using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Kata.Helpers
{
    [Flags]
    public enum MenuFlags { ClearScreenFirst, SelectWithReadKey, GenerateExitOption };
    public struct MenuSettings
    {
        public MenuFlags Flags { get; }
        public bool SelectWithReadKey { get; }
        public ConsoleKey ExitKey { get; }
        public int DefaultOption { get; }
        public bool GenerateExitOption { get; }
        public string Prompt { get; }
        public bool ClearScreenFirst { get; }
        
        public MenuSettings(bool selectWithReadKey, ConsoleKey exitKey, 
            int defaultOption, bool generateExitOption, string prompt,
            bool clearScreenFirst, MenuFlags flags = MenuFlags.ClearScreenFirst | MenuFlags.GenerateExitOption)
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
    public class MenuHelperDone<T>
    {
        private List<Type> options = new List<Type>();
        public List<Type> Options { get => options; }
        private MenuSettings settings;

        public static MenuHelperDone<T> CreateMenu()
        {
            return buildMenu(typeof(T));
        }

        private static MenuHelperDone<T> buildMenu(Type menuSourceType)
        {
            var typesInAssembly = menuSourceType.Assembly.DefinedTypes.Where(t => !t.IsAbstract);
            var newMenu = new MenuHelperDone<T>();
            
            var targetTypes = (menuSourceType.IsInterface)
                ? typesInAssembly.Where(t => t.ImplementedInterfaces.Contains(menuSourceType))
                : typesInAssembly.Where(t => t.IsSubclassOf(menuSourceType));

            var numTypes = targetTypes.Count();
            newMenu.Configure(MenuFlags.ClearScreenFirst | MenuFlags.GenerateExitOption, $"Selection ({numTypes}): ", numTypes);
            
            foreach (var defType in targetTypes)
            {
                newMenu.Options.Add(defType);
            }

            return newMenu;
        }

        public void DisplayMenu()
        {
            if (settings.ClearScreenFirst)
            {
                Console.Clear();
            }

            var optionNumber = 0;
            foreach(var option in Options)
            {
                Console.WriteLine($"{++optionNumber,-3} - {option.Name}" +
                    $"{(settings.DefaultOption == optionNumber ? " (default)" : "")}");
            }

            if (settings.GenerateExitOption)
            {
                if (settings.SelectWithReadKey)
                {
                    Console.WriteLine($"{settings.ExitKey} - Exit");
                }
                else
                {
                    Console.WriteLine($"{++optionNumber,-3} - Exit");
                }
            }
            Console.WriteLine();
        }


        public T SelectFromMenu(string prompt)
        {
            DisplayMenu();

            var selection = 0;

            var gotSelection = (settings.Flags.HasFlag(MenuFlags.SelectWithReadKey))
                ? ConsoleHelperDone.GetInteger(prompt, out selection, new KeyRangeValidatorDone(1, options.Count))
                : ConsoleHelperDone.GetInteger(prompt, out selection, new RangeValidatorDone(1, options.Count));

            if (!gotSelection) return default;

            var ctors = options[selection - 1].GetConstructors();
            if (ctors.Any(c => c.GetParameters().Length == 0))
            {
                return (T)options[selection - 1].Assembly.CreateInstance(options[selection - 1].FullName);
            }

            var minArgs = ctors.Min(m => m.GetParameters().Length);
            var minCtor = ctors.Single(c => c.GetParameters().Length == minArgs);
            var args = minCtor.GetParameters();
            var instArgs = new List<object>();
            for (var i = 0; i < args.Length; i++)
            {
                var arg = args[i];
                if (arg.ParameterType.IsArray)
                {
                    var children = arg.ParameterType.Assembly.DefinedTypes
                        .Where(t => t.BaseType?.FullName == arg.ParameterType.FullName.Replace("[]", ""))
                        .ToList();
                    foreach(var c in children)
                    {
                        instArgs.Add(c.Assembly.CreateInstance(c.FullName));
                    }
                    continue;
                }
                instArgs.Add(arg.ParameterType.Assembly.CreateInstance(arg.ParameterType.FullName));
            }

            return (T)options[selection - 1].Assembly.CreateInstance(
                options[selection - 1].FullName, false, System.Reflection.BindingFlags.Default, null, instArgs.ToArray(), null, null);
        }

        public void Configure(MenuFlags flags, string prompt, int defaultOption)
        {
            Configure(flags.HasFlag(MenuFlags.SelectWithReadKey), ConsoleKey.Escape, defaultOption, flags.HasFlag(MenuFlags.GenerateExitOption)
                , prompt, flags.HasFlag(MenuFlags.ClearScreenFirst), flags);
        }
        public void Configure(MenuFlags flags, string prompt, int defaultOption, ConsoleKey exitKey)
        {
            Configure(flags.HasFlag(MenuFlags.SelectWithReadKey), exitKey, defaultOption, flags.HasFlag(MenuFlags.GenerateExitOption)
                , prompt, flags.HasFlag(MenuFlags.ClearScreenFirst), flags);
        }
        public void Configure(bool selectWithReadKey, ConsoleKey exitKey, int defaultOption, 
            bool generateExitOption, string prompt, bool clearScreenFirst, MenuFlags flags)
        {
            settings = new MenuSettings(selectWithReadKey, exitKey, defaultOption, generateExitOption, prompt, clearScreenFirst, flags);
        }
    }
}
