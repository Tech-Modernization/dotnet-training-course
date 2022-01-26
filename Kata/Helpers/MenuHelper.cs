using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Reflection;
using System.Collections;
using Helpers.Extensions;

namespace Helpers
{

    public class MenuHelper
    {
        public static KeyFunctionMap DefaultKeyFunctionMap = new KeyFunctionMap()
                {
                    {ConsoleKey.Q, cki => FilterMenuAction.ReturnForCustomAction },
                    {ConsoleKey.End, cki => FilterMenuAction.ReturnLast },
                    {ConsoleKey.Home, cki => FilterMenuAction.ReturnFirst },
                    {ConsoleKey.Backspace, cki => FilterMenuAction.RemoveLastKey },
                    {ConsoleKey.Delete, cki => FilterMenuAction.RemoveLastKey },
                    {ConsoleKey.PageUp, cki => FilterMenuAction.ReturnForCustomAction },
                    {ConsoleKey.PageDown, cki => FilterMenuAction.ReturnForCustomAction },
                    {ConsoleKey.Insert, cki => FilterMenuAction.DivertToCustomAction }
                };
        protected List<MenuItemBase> Options { get; }
        public MenuSettings Settings { get; }

        public MenuFlags SettingsFlags
        {
            get
            {
                return Settings.Flags;
            }
            set
            {
                Settings.ClearScreenFirst = value.HasFlag(MenuFlags.ClearScreenFirst);
                Settings.GenerateExitOption = value.HasFlag(MenuFlags.GenerateExitOption);
                Settings.SelectWithReadKey = value.HasFlag(MenuFlags.SelectWithReadKey);
                Settings.Flags = value;
            }
        }

        public MenuHelper()
        {
            Settings = new MenuSettings();
            Options = new List<MenuItemBase>();
        }

        public void Clear()
        {
            Options.Clear();
        }

        public void Build(Func<List<MenuItemBase>> optionGenerator, Action<Type> itemRunner = null)
        {
            var options = optionGenerator();
            for (var o = 0; o < options.Count; o++)
            {
                var opt = options[o];
                opt.Run = itemRunner;
                Options.Add(opt);
            }
        }

        public MenuItemBase this[int i]
        {
            get => Options.SingleOrDefault(o => o.Index == i);
        }

        public static List<MenuItemBase> GetTypedMenuItems(List<Type> types)
        {
            return types.Select(t => new MenuItemBase() { Index = types.IndexOf(t) + 1, Text = t.FullName, ImplementedAs = t }).ToList();
        }

        public void DisplayMenu()
        {
            if (Settings.ClearScreenFirst)
            {
                Console.Clear();
            }

            foreach(var option in Options)
            {
                Console.WriteLine($"{option.Index,-3} - {option.Text}" +
                    $"{(Settings.DefaultOption == option.Index ? " (default)" : "")}");
            }

            if (Settings.GenerateExitOption)
            {
                if (Settings.SelectWithReadKey)
                {
                    Console.WriteLine($"{Settings.ExitKey} - Exit");
                }
                else
                {
                    Settings.ExitOption = Options.Count + 1;
                    Console.WriteLine($"{Settings.ExitOption,-3} - Exit");
                }
            }
            Console.WriteLine();
        }

        public int SelectFromMenu(string prompt = null)
        {
            if (prompt == null)
                prompt = Settings.Prompt;

            DisplayMenu();

            var selection = 0;

            var gotSelection = (Settings.Flags.HasFlag(MenuFlags.SelectWithReadKey))
                ? ConsoleHelper.GetInteger(prompt, out selection, new KeyRangeValidator(1, Options.Count))
                : ConsoleHelper.GetInteger(prompt, out selection, new RangeValidator(1, Options.Count));

            if (gotSelection)
            {
                var opt = this[selection];
                if (opt.Run != null)
                    opt.Run(opt.ImplementedAs);
            }
            return gotSelection ? selection : Settings.DefaultOption;
        }

        public int AddOption(string optionText)
        {
            var newOpt = new MenuItemBase() { Index = Options.Count + 1, Text = optionText };
            Options.Add(newOpt);
            return newOpt.Index;
        }

        public void Configure(MenuFlags flags, string prompt, int defaultOption)
        {
            Configure(flags.HasFlag(MenuFlags.SelectWithReadKey), ConsoleKey.Escape, defaultOption, flags.HasFlag(MenuFlags.GenerateExitOption)
                , prompt, flags.HasFlag(MenuFlags.ClearScreenFirst), flags);
        }

        public class KeyFunctionMap : Dictionary<ConsoleKey, Func<string, FilterMenuAction>>
        {

        }

        public enum FilterMenuAction
        {
            ReturnLast = 1,
            ReturnFirst,
            ReadNextKey,
            RemoveLastKey,
            RemoveAllKeys,
            ReturnForCustomAction,
            DivertToCustomAction,
            SelectByIndex
        }

        public static T FilterMenu<T>(List<T> items, Func<T, string, bool> filter, KeyFunctionMap keyFuncMap = null, string prompt = "Start typing to filter the list: ")
        {
            Console.Clear();
            var keyInfo = default(ConsoleKeyInfo);
            var key = keyInfo.Key;
            var keyChar = keyInfo.KeyChar;
            var keys = new List<ConsoleKeyInfo>();
            var filteredItems = items;
            
            if (keyFuncMap == null)
            {
                keyFuncMap = DefaultKeyFunctionMap;
            }

            if (filter == null)
            {
                filter = (item, filterString) => $"{item}".ToLower().Contains(filterString.ToLower()) || filterString.ToInteger(filteredItems.Count + 1) <= filteredItems.Count;
            }

            while (filteredItems.Count != 1)
            {
                var filterString = GetKeyString(keys);
                filteredItems = items.Where(item => filter(item, filterString)).ToList();

                SetupIndexSelection(keyFuncMap, filteredItems);

                formatList(filteredItems, prompt);

                Console.Write(filterString);
                keyInfo = Console.ReadKey();
                if (char.IsLetterOrDigit(keyInfo.KeyChar) || char.IsPunctuation(keyInfo.KeyChar))
                {
                    keys.Add(keyInfo);
                }

                if (keyFuncMap.ContainsKey(keyInfo.Key))
                {
                    switch (keyFuncMap[keyInfo.Key](GetKeyString(keys)))
                    {
                        case FilterMenuAction.ReturnLast:
                            return filteredItems.Last();
                        case FilterMenuAction.ReturnFirst:
                            return filteredItems.First();
                        case FilterMenuAction.ReadNextKey:
                            continue;
                        case FilterMenuAction.RemoveLastKey:
                            if (keys.Count > 0) keys.Remove(keys.Last());
                            break;
                        case FilterMenuAction.RemoveAllKeys:
                            keys.Clear();
                            break;
                        case FilterMenuAction.ReturnForCustomAction:
                            return default;
                        case FilterMenuAction.SelectByIndex:
                            return filteredItems.ElementAt(int.Parse(GetKeyString(keys)) - 1);
                    }
                }
            }
            return filteredItems.First();
        }

        private static string GetKeyString(List<ConsoleKeyInfo> keys)
        {
            return string.Join("", keys.Select(ki => ki.KeyChar));
        }

        private static void SetupIndexSelection<T>(KeyFunctionMap keyFuncMap, List<T> filteredItems)
        {
            for(var ck = ConsoleKey.D0; ck <= ConsoleKey.D9; ck++)
            {
                keyFuncMap.Remove(ck);
            }

            for(var ck = ConsoleKey.D0; ck <= ConsoleKey.D9; ck++)
            {
                    keyFuncMap.Add(ck, (keyString) => GetFilterMenuAction(keyString, filteredItems));
            }
        }
        private static FilterMenuAction GetFilterMenuAction<T>(string keyString, List<T> filteredItems)
        {
            var menuIndex = 0;

            return int.TryParse(keyString, out menuIndex)
                    ? (menuIndex <= filteredItems.Count)
                        ? (menuIndex * 10) > filteredItems.Count
                            ? FilterMenuAction.SelectByIndex
                            : FilterMenuAction.ReadNextKey
                        : FilterMenuAction.RemoveLastKey
                    : FilterMenuAction.ReadNextKey;
        }


        private static void formatList<T>(List<T> filteredItems, string prompt)
        {
            Console.Clear();
            Console.WriteLine(prompt);
            Console.WriteLine(string.Join("\n", filteredItems.Select(item => $"[{filteredItems.IndexOf(item) + 1:D2}] - {item}")));

            Console.WindowTop = 0;
            Console.WindowLeft = 0;
            Console.CursorTop = 0;
            Console.CursorLeft = prompt.Length;
        }

        public static MenuSelectionItemBase SelectByKeySequence(IMenu menu)
        {
            // common elements of these steps:
            foreach (KeyStepBase keyStep in menu)
            {
                // 0. format the prompt (we need to use the previous answers to formulate the next question).
                // 1. the question
                var key = keyStep.Ask();
                // 1.1  did they abort the question?
                if (key == ConsoleKey.Q) return menu.SelectionItem;

                // 3. filling in the relevant bit of the selection item
                keyStep.ConvertKeyToSelectionData();
            }

            return menu.SelectionItem;
        }
        public static T SelectMulti<T>(IMenu menu)
            where T : MenuSelectionBase, new()
        {
            var selection = new T();

            Console.Clear();
            menu.Display();

            var ynKey = default(ConsoleKey);
            do
            {
                var selectionItem = SelectByKeySequence(menu);

                // did they abort the sequence?
                if (selectionItem.IsComplete)
                {
                    // add to the order
                    selection.Add(selectionItem);
                }
                else
                {
                    Console.WriteLine("Item cancelled.");
                }
                // ask if they want anything else
                ynKey = ConsoleHelper.GetKey("Anything else? [Y]es/[N]o: ", false, ConsoleKey.Y, ConsoleKey.N);
            }
            while (ynKey == ConsoleKey.Y);


            return selection;
        }



        public void Configure(MenuFlags flags, string prompt, int defaultOption, ConsoleKey exitKey)
        {
            Configure(flags.HasFlag(MenuFlags.SelectWithReadKey), exitKey, defaultOption, flags.HasFlag(MenuFlags.GenerateExitOption)
                , prompt, flags.HasFlag(MenuFlags.ClearScreenFirst), flags);
        }
        public void Configure(bool selectWithReadKey, ConsoleKey exitKey, int defaultOption, 
            bool generateExitOption, string prompt, bool clearScreenFirst, MenuFlags flags)
        {
            Settings.ClearScreenFirst = clearScreenFirst;
            Settings.DefaultOption = defaultOption;
            Settings.ExitKey = exitKey;
            Settings.Flags = flags;
            Settings.GenerateExitOption = generateExitOption;
            Settings.Prompt = prompt;
            Settings.SelectWithReadKey = selectWithReadKey;
        }

        public void RealiseSelectedOption()
        {
            /* sort this out
            var ctors = options[selection - 1].GetConstructors();
               if (ctors.Any(c => c.GetParameters().Length == 0))
               {
                   return (T) options[selection - 1].Assembly.CreateInstance(options[selection - 1].FullName);
               }
            */
            var ctors = typeof(MenuItemBase).GetConstructors();
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
                    foreach (var c in children)
                    {
                        instArgs.Add(c.Assembly.CreateInstance(c.FullName));
                    }
                    continue;
                }
                instArgs.Add(arg.ParameterType.Assembly.CreateInstance(arg.ParameterType.FullName));
            }
            /*...and this
                        return (T) options[selection - 1].Assembly.CreateInstance(
                            options[selection - 1].FullName, false, System.Reflection.BindingFlags.Default, null, instArgs.ToArray(), null, null);
                    }
            */
        }

        public IEnumerator GetEnumerator()
        {
            return ((IEnumerable)Options).GetEnumerator();
        }
    }
}
