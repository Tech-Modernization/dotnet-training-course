using System;
using System.Collections.Generic;
using System.Text;

namespace CustomTypes.MenuFactory
{
    public abstract class MenuBase
    {
        private List<MenuItemBase> items = new List<MenuItemBase>();
        public List<MenuItemBase> Items
        {
            get { return items; }
        }

        public MenuBase()
        {
            this.CreateMenuItems();
        }

        protected abstract void CreateMenuItems();

    }
}
