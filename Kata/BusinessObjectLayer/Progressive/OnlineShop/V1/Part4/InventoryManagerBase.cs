using System.Collections.Generic;
using ImplementationLayer;

namespace BusinessObjectLayer.OnlineShop.Part4
{
    public abstract class InventoryManagerBase : IInventoryManager
    {
        protected IFileDataService DataService;
        protected List<Product> Products;

        public InventoryManagerBase(IFileDataService dataService)
        {
            DataService = dataService;
            LoadProducts();
        }

        public abstract List<Product> GetProducts(string searchText);
        public abstract void LoadProducts();
    }
}