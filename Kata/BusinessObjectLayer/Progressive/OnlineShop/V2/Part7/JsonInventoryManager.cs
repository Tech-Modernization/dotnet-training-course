using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Helpers;

namespace BusinessObjectLayer.Progressive.OnlineShop.V2.Part7
{
    // resp: manage the inventory
    public class JsonInventoryManager : IInventoryManager
    {
        IInteractor interactor;
        private const string dbPath = "online-shop-inventory.json";
        IJsonDataService jsonDataService;
        private ShopDb shopDb;

        public JsonInventoryManager(IJsonDataService jsonDataService, IInteractor interactor)
        {
            this.interactor = interactor;
            this.jsonDataService = jsonDataService;
            shopDb = Load();
        }

        public List<Product> Search(string searchText)
{
            var safeName = searchText.Replace(" ", "").ToLower();
            var matches = shopDb.Products.Where(prod => prod.Name.Replace(" ", "").ToLower().Contains(safeName)).ToList();
            return matches;
        }

        private ShopDb Load()
        {
            return jsonDataService.GetJsonObject(dbPath).ToObject<ShopDb>();
        }

        public void Manage()
        {
            var key = default(ConsoleKey);
            while (key != ConsoleKey.Q)
            {
                key = interactor.GetKey("[A]dd, [E]dit or [D]elete Product? ", ConsoleKey.A, ConsoleKey.E, ConsoleKey.D);
                switch (key)
                {
                    case ConsoleKey.E:
                        break;
                    case ConsoleKey.A:
                        AddProduct();
                        break;
                    case ConsoleKey.D:
                        DeleteProduct();
                        break;
                }
            }

            jsonDataService.Save(dbPath, shopDb);
        }

        private Product GetProduct()
        {
            var product = string.Empty;
            var gotEmail = interactor.GetString("Product: ", out product);
            return shopDb.Products.SingleOrDefault(prod => prod.Name.Collapse() == product.Collapse()) ?? new Product(product, 10M);
        }

        private void AddProduct()
        {
            var product = GetProduct();
            if (product != null)
            {
                if (product.IsNew)
                {
                    shopDb.Products.Add(product);
                }
            }
        }

        private void DeleteProduct()
        {
            var prod = GetProduct();
            if (prod != null)
            {
                shopDb.Products.Remove(prod);
            }
        }

        private void EditProduct(Product Product)
        {
            throw new NotImplementedException();
        }
    }
}
