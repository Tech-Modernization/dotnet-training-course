using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace Kata.CustomTypes.OnlineShop.Part6
{
    public class CsvInventoryService : IInventoryService
    {
        private IFileDataService dataService;

        public CsvInventoryService(IFileDataService dataService)
        {
            this.dataService = dataService;
        }

        public List<Product> Load()
        {
            var products = new List<Product>();
            var csvContents = dataService.GetLines("online-shop-inventory.csv");
            foreach (var csv in csvContents)
            {
                var tokens = csv.Split(",");
                var newt = new Product();
                PopulateProduct(newt, tokens.ToList());
                products.Add(newt);
            }
            return products;
        }

        public void PopulateProduct(Product p, List<string> tokens)
        {
            p.Name = tokens[0];
            p.Price = decimal.Parse(tokens[1]);
        }
    }
}
