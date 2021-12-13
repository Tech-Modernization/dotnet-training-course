using System.Collections.Generic;

using Kata.DataServices;

using Newtonsoft.Json;

namespace Kata.Services
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
