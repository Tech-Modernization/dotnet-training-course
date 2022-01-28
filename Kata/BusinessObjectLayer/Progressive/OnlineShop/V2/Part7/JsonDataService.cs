using System;
using Newtonsoft.Json.Linq;
using Helpers;

namespace BusinessObjectLayer.Progressive.OnlineShop.V2.Part7
{
    public class JsonDataService : IJsonDataService
    {
        public JArray GetJsonArray(string path)
        {
            return FileHelper.ImportJson<JArray>(path);
        }

        public JObject GetJsonObject(string path)
        {
            return FileHelper.ImportJson<JObject>(path);
        }

        public void Save(string dbPath, object objToSerialise)
        {
            FileHelper.Save(dbPath, objToSerialise);
        }
    }
}