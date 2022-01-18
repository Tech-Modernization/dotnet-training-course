using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace Helpers
{
    public class FileHelper
    {
        private static string DefaultCurrentDirectory = Path.GetFullPath(".");
        public static T ImportJson<T>(string path) => JsonConvert.DeserializeObject<T>(path);
        public static string GetJsonPath(string dbDir)
        {
            var m = new MenuHelper();
            m.Build(() => FileHelper.FindByExtension(dbDir, ".json").Select(f => new MenuItemBase { Text = f }).ToList());
            var selected = m.SelectFromMenu("Select JSON file: ");
            return m[selected - 1].Text;
        }

        public static string Browse(string currentSelection = ".", bool recursive = true, Func<bool, string, bool> stopBrowsing = null, int level = 0)
        {
            if (level > 15) return "StackOverflowGuard";

            var keyFuncMap = MenuHelper.DefaultKeyFunctionMap;
            var customKeyPressed = ConsoleKey.Escape;
            keyFuncMap[ConsoleKey.PageUp] = cki =>
            {
                customKeyPressed = cki.Key;
                Environment.CurrentDirectory = "..";
                return MenuHelper.FilterMenuAction.ReturnForCustomAction;
            };

            if (stopBrowsing == null)
            {
                // default behaviour is stop browsing once they select a file
                stopBrowsing = (isDir, path) => !File.GetAttributes(path).HasFlag(FileAttributes.Directory);
            }

            var items = new List<string>(Directory.GetFiles(currentSelection).Select(f => Path.GetFullPath(f)));
            items.AddRange(new List<string>(Directory.GetDirectories(currentSelection).Select(f => Path.GetFullPath(f))));
            items.Insert(0, "..");
            var selection = currentSelection;
            while (!stopBrowsing(File.GetAttributes(selection).HasFlag(FileAttributes.Directory), selection))
            {
                selection = MenuHelper.FilterMenu(items, (path, filter) => path.ToUpper().Contains(filter.ToUpper()) || path == "..", keyFuncMap);
                if (selection == null)
                {
                    // a custom action was indicated by a keystroke inside FilterMenu
                    if (customKeyPressed == ConsoleKey.PageUp)
                    {
                        // already moved up one
                        selection = Browse(Environment.CurrentDirectory, recursive, stopBrowsing, level + 1);
                    }

                }
                else if (File.GetAttributes(selection).HasFlag(FileAttributes.Directory) && recursive)
                {
                    Environment.CurrentDirectory = selection;
                    selection = Browse(selection, recursive, stopBrowsing, level + 1);
                }
            }

            if (level == 0)
            {
                Environment.CurrentDirectory = DefaultCurrentDirectory;
                Console.Clear();
            }
            return selection;
        }

        public static void Append(string reportFile, object item)
        {
            File.AppendAllText(reportFile, $"{item}");
        }

        public static List<string> FindByExtension(string path, string ext) => Directory.GetFiles(path)
            .Where(f => Path.GetExtension(f) == ext)
            .Select(f => Path.GetFullPath(f))
            .ToList();
        
    }
}
