using System.Collections.Generic;

namespace Kata.CustomTypes.MenuFactoryDic
{
    public abstract class MenuBase
    {
        // 1. backing store for the list of items
        private List<MenuItemBase> items = new List<MenuItemBase>();
        
        // 2. readonly property to access the backing store
        public List<MenuItemBase> Items { get { return items; } }

        // 3. constructor to call the Factory Method
        public MenuBase()
        {
            this.CreateMenuItems();
        }

        // 4. definition of the factory method which all children must implement.
        protected abstract void CreateMenuItems();
        
    }
}
