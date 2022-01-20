using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.IO;

namespace BusinessObjectLayer.Soshal
{
    public class JsonDataService : IJsonDataService
    {
        public JObject Load(string path)
        {
            try
            {
                return JsonConvert.DeserializeObject<JObject>(File.ReadAllText(path));
            }
            catch (Exception ex)
            {
                throw new Exception("Error loading Soshal database", ex);
            }
        }

        public void Save(object db, string path)
        {
            try
            {
                File.WriteAllText(path, JsonConvert.SerializeObject(db));
            }
            catch (Exception ex)
            {
                throw new Exception("Error saving Soshal database", ex);
            }
        }
    }
}