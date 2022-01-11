using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Newtonsoft.Json;

namespace Helpers
{
    public class FileHelper
    {
        public static T ImportJson<T>(string path) => JsonConvert.DeserializeObject<T>(path);
        public static string GetJsonPath(string dbDir)
        {
            var m = new MenuHelper();
            m.Build(() => FileHelper.FindByExtension(dbDir, ".json").Select(f => new MenuItemBase { Text = f }).ToList());
            var selected = m.SelectFromMenu("Select JSON file: ");
            return m[selected - 1].Text;
        }

        public static List<string> FindByExtension(string path, string ext) => Directory.GetFiles(path)
            .Where(f => Path.GetExtension(f) == ext)
            .Select(f => Path.GetFullPath(f))
            .ToList();
        
    }
}
