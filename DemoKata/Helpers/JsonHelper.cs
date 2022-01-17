using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.IO;

namespace Helpers
{ 
    public static class JsonHelper
    {
        public static T LoadAs<T>(string path, string prop = null)
        {
            try
            {
                var jsonText = File.ReadAllText(path);
                var jobject = JObject.Parse(jsonText);
                return prop == null ? jobject.ToObject<T>() : jobject[prop].ToObject<T>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading json file: \n{ex}");
                return default;
            }
        }
        public static bool SaveAs(object dsObject, string path)
        {
            try
            {
                if (Directory.Exists(Path.GetDirectoryName(path)))
                {
                    var jsonText = JsonConvert.SerializeObject(dsObject);
                    File.WriteAllText(path, jsonText);
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving json file {Path.GetFullPath(path)}: \n{ex}");

                return false;
            }
        }
    }
}
