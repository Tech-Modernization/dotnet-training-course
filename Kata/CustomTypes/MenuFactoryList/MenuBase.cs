using System.Collections.Generic;
namespace Kata.CustomTypes.MenuFactoryList
{
    public abstract class MenuBase
    {
        // backing store
        private List<MenuItemBase> items = new List<MenuItemBase>();
        // readonly property
        public List<MenuItemBase> Items { get { return items; } }
        // constructor
        public MenuBase()
        {
            this.CreateItems();
        }

        // factory method
        protected abstract void CreateItems();
    }
}
