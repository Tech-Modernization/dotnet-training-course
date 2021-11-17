using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

using Newtonsoft.Json;

namespace Kata.CustomTypes.OnlineShop.Part6
{
    public class JsonInventoryService : IInventoryService
    {
        private IFileDataService dataService;

        public JsonInventoryService(IFileDataService dataService)
        {
            this.dataService = dataService;
        }

        public List<Product> Load()
        {
            var csvContents = dataService.GetLines("online-shop-inventory.json");
            return JsonConvert.DeserializeObject<List<Product>>(string.Join("", csvContents));
        }
    }
}
