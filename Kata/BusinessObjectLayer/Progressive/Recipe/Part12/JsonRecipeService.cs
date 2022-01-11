using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace BusinessObjectLayer.Recipe.Part12
{
    public class JsonRecipeService : IRecipeService
    {
        private IDataService dataService;
        public JsonRecipeService(IDataService _dataService)
        {
            dataService = _dataService;
        }
        public List<string> LoadPantry()
        {
            var jsonText = dataService.GetContents("cookbook.json");
            var jobject = JObject.Parse(jsonText);

         //   return jobject.GetValue("ingredients").ToObject<List<string>>();
            return jobject["ingredients"].ToObject<List<string>>();
        }
    }

    /* an notional example of what JObject is doing in order to provide
     * the syntax on line 26
     public class Program
    {
        public static void Main(string args[])
    {
            var jd = new JsonDoc();
            var i = jd["ingredients"];
    }

    public class JsonProperty
    {
        public string Name;        
    }
    public class JsonDoc 
    {
        private Dictionary<string, JsonProperty> internalData;

        public JsonProperty GetValue(string propertyName)
        {
            return internalData.ContainsKey(propertyName) ? internalData[propertyName] : null;
        }

        public JsonProperty this[string propertyName]
        {
            // get => internalData.ContainsKey(propertyName) ? internalData[propertyName] : null;
            get => GetValue(propertyName);
        }
    }
    */
}
