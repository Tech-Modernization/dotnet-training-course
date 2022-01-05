using System.Collections.Generic;
namespace Kata.CustomTypes.MenuFactoryList
{
    public abstract class MenuBase
    {
        public string Name { get; set; }
        // backing store
        private List<MenuItemBase> items = new List<MenuItemBase>();
        // readonly property
        public List<MenuItemBase> Items { get { return items; } }
        // constructor
        public MenuBase(string title)
        {
            Name = title;
            this.CreateMenuItems();
        }

        // factory method
        protected abstract void CreateMenuItems();

        // formatting for display
        public override string ToString()
        {
            var line1 = $"- - - - - - - - - - {Name} - - - - - - - - - -";
            return $"{line1}\n{new string('-', line1.Length)}\n";
        }
    }
}
