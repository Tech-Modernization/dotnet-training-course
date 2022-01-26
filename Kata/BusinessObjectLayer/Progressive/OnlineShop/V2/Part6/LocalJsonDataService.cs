using System;
using Newtonsoft.Json.Linq;
using Helpers;

namespace BusinessObjectLayer.Progressive.OnlineShop.V2.Part6
{
    public class LocalJsonDataService : IJsonDataService
    {
        public JArray GetJsonArray(string path)
        {
            return FileHelper.ImportJson<JArray>(path);
        }

        public JObject GetJsonObject(string path)
        {
            return FileHelper.ImportJson<JObject>(path);
        }
    }
}