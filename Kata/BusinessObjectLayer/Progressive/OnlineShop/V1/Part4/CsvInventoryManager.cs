using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjectLayer.Extensions;
using ImplementationLayer;

namespace BusinessObjectLayer.OnlineShop.Part4
{
    public class CsvInventoryManager : InventoryManagerBase
    {
        public CsvInventoryManager(IFileDataService dataService) : base(dataService)
        {
        }

        public override List<Product> GetProducts(string searchText)
        {
            var spaceCaseBlind = searchText.Collapse();
            return Products.Where(p => p.Name.Collapse().Contains(spaceCaseBlind)).ToList();
        }

        public override void LoadProducts()
        {
            Products = DataService.GetLines("../../../online-shop-inventory.csv")
                .Select(csv =>
                {
                    var tokens = csv.Split(',');
                    return new Product(tokens[0], decimal.Parse(tokens[1]));
                }).ToList();
        }
    }
}
