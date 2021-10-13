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
            CreateVariants();
        }
        // 4. factory method
        protected virtual void CreateVariants()
        {
            Variants.Add(new MenuItemVariant(Name, price));
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            if (Variants.Count > 1)
            {
                sb.AppendLine($"{Name} sub-menu");
            }

            foreach(var v in Variants)
            {
                sb.AppendLine($"    {v}");
            }
            return sb.ToString();
        }
    }
}
