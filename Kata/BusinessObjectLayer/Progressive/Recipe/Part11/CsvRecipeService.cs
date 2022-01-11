using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace BusinessObjectLayer.Recipe.Part11
{
    public class CsvRecipeService : IRecipeService
    {
        private IDataService dataService;
        public CsvRecipeService(IDataService _dataService)
        {
            dataService = _dataService;
        }
        public List<string> LoadPantry()
        {
            var rawIngredientRecords = dataService.GetList("ingredients.csv");
            return rawIngredientRecords.Select(rec => rec.Split(',').First()).ToList();
        }
    }
}
