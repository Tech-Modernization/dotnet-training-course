using System.Collections.Generic;

namespace Kata.CustomTypes.MenuFactoryDic
{
    public abstract class MenuBase<T1>
    {
        private List<MenuItemBase<T>> items = new List<MenuItemBase>();
        public List<MenuItemBase> Items { get { return items; } }
        public MenuBase()
        {
            this.CreateMenuItems();
        }
        protected abstract void CreateMenuItems();
    }
}
