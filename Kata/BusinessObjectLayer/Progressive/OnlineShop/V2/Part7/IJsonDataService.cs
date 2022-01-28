using Newtonsoft.Json.Linq;

namespace BusinessObjectLayer.Progressive.OnlineShop.V2.Part7
{
    public interface IJsonDataService
    {
        JObject GetJsonObject(string path);
        JArray GetJsonArray(string path);
        void Save(string dbPath, object objToSerialise);
    }
}