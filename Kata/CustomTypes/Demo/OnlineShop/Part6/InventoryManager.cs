using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Kata.CustomTypes.OnlineShop.Part6
{
    public class InventoryManager : IInventoryManager
    {
        private IInventoryService inventoryService;
        private List<Product> inventory;

        public InventoryManager(IInventoryService inventoryService)
        {
            this.inventoryService = inventoryService;
        }

        public void Load()
        {
            inventory = inventoryService.Load();
        }

        public List<Product> Get()
        {
            return inventory;
        }
    }
}
