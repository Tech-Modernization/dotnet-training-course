using System.Collections.Generic;
using Newtonsoft.Json;
using ImplementationLayer;

namespace BusinessServiceLayer
{
    public class JsonRecipeService : IRecipeService
    {
        private IFileDataService dataService;

        public JsonRecipeService(IFileDataService dataService)
        {
            this.dataService = dataService;
        }

        public Dictionary<string,string> LoadPantry()
        {
            var jsonText = dataService.GetContents("ingredients.json");
            return JsonConvert.DeserializeObject<Dictionary<string,string>>(jsonText);
        }
    }
}
