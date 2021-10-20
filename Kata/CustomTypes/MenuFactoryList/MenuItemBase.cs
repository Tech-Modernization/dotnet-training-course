using System.Collections.Generic;
using System.Text;

namespace Kata.CustomTypes.MenuFactoryList
{
    public abstract class MenuItemBase
    {
        protected string Name { get; set; }
        private decimal price;
        // 1. backing store
        private List<MenuItemVariant> variants = new List<MenuItemVariant>();
        // 2. property access
        public List<MenuItemVariant> Variants { get { return variants; } }
        // 3. constructor
        public MenuItemBase(string name, decimal price)
        {
            Name = name;
            this.price = price;
            this.CreateVariants();
        }
        // 4. factory method
        protected virtual void CreateVariants()
        {
            Variants.Add(new MenuItemVariant(Name, price));
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            var indent = string.Empty;
            if (Variants.Count > 1)
            {
                sb.Append($"\n{Name} sub-menu");
                indent = new string(' ', 4);
            }

            foreach(var v in Variants)
            {
                sb.Append($"\n{indent}{v}");
            }
            return sb.ToString();
        }
    }
}
