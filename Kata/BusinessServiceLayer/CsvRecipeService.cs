using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

using Kata.DataServices;

namespace Kata.Services
{
    public class CsvRecipeService : IRecipeService
    {
        private IFileDataService dataService;

        public CsvRecipeService(IFileDataService dataService)
        {
            this.dataService = dataService;
        }

        public Dictionary<string, string> LoadPantry()
        {
            var pantry = new Dictionary<string, string>();
            var csvLines = dataService.GetLines("ingredients.csv");
            foreach (var csv in csvLines)
            {
                var tokens = csv.Split(",");
                pantry.TryAdd(tokens[0], tokens[1]);
            }
            return pantry;
        }
    }
}
