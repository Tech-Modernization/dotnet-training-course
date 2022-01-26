using Newtonsoft.Json.Linq;

namespace BusinessObjectLayer.Progressive.OnlineShop.V2.Part6
{
    public interface IJsonDataService
    {
        JObject GetJsonObject(string path);
        JArray GetJsonArray(string path);
    }
}