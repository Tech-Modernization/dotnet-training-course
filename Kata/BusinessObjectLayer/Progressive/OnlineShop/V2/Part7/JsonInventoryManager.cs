using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace BusinessObjectLayer.Progressive.OnlineShop.V2.Part7
{
    // resp: manage the inventory
    public class JsonInventoryManager : IInventoryManager
    {
        IJsonDataService jsonDataService;
        List<Product> stock;

        public JsonInventoryManager(IJsonDataService jsonDataService)
        {
            this.jsonDataService = jsonDataService;
            stock = Load();
        }

        public List<Product> Search(string searchText)
{
            var safeName = searchText.Replace(" ", "").ToLower();
            var matches = stock.Where(prod => prod.Name.Replace(" ", "").ToLower().Contains(safeName)).ToList();
            return matches;
        }

        private List<Product> Load()
        {
            return jsonDataService.GetJsonArray("../../../online-shop-inventory.json")?.ToObject<List<Product>>();
        }
    }
}
