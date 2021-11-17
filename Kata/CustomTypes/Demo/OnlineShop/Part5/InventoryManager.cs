using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Kata.CustomTypes.OnlineShop.Part5
{
    public class InventoryManager : IInventoryManager
    {
        private Dictionary<string, decimal> inventory = new Dictionary<string, decimal>();

        public void Load()
        {
            var csvContents = File.ReadAllLines("online-shop-inventory.csv").ToList();
            foreach (var csv in csvContents)
            {
                var tokens = csv.Split(",");
                inventory.TryAdd(tokens[0], decimal.Parse(tokens[1]));
            }
        }

        public List<Product> Get()
        {
            return inventory.Select(kvp => new Product() { Name = kvp.Key, Price = kvp.Value }).ToList();
        }
    }
}
