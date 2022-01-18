using System.Collections.Generic;

namespace Helpers
{
    public abstract class MenuSelectionBase 
    {
        protected List<MenuSelectionItemBase> Items { get; }
        public MenuSelectionBase()
        {
            Items = new List<MenuSelectionItemBase>();
        }

        public abstract void Add(MenuSelectionItemBase item);
    }
}