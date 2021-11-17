using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

using Newtonsoft.Json;

using Kata.DataServices;

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
