using Newtonsoft.Json.Linq;

namespace BusinessObjectLayer.Soshal
{
    public interface IJsonDataService
    {
        JObject Load(string path);
        void Save(object db, string path);
    }
}