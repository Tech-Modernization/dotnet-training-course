using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kata.CustomTypes.MenuFactoryList
{
    public class DrinkMenuItem : MenuItemBase
    {
        public DrinkMenuItem() : base()
        {
            this.CreateVariants();
        }
        public DrinkMenuItem(string name, decimal price) : base(name, price)
        {
            AddVariant(name, price);
        }
        public void AddVariant(string name, SizeVariant size, decimal price)
        {
            if (Variants.Any(variant => variant.GetType().Name == "MenuItemVariant"))
            {
                Console.WriteLine($"Cannot mix fixed-price menu items with price-variant items.  Price-variants will be given precedence.");
                for (var i = 0; i < Variants.Count; i++)
                {
                    var v = Variants[i];
                    if (v.GetType().Name == "MenuItemVariant")
                    {
                        Console.WriteLine($"Removing fixed price variant -> {v}");
                        Variants.Remove(v);
                    }
                }
            }
            Variants.Add(new DrinkMenuItemVariant(name, price, size));
        }

        protected override void CreateVariants()
        {
            // nothing to do here
        }

        public override string ToString()
        {
            if ((Variants?.Count ?? 0) == 0) return base.ToString();

            var sb = new StringBuilder();
            sb.AppendLine($"{base.Name} Sub-Menu");
            foreach(var v in Variants)
            {
                sb.AppendLine(v.ToString());
            }
            return sb.ToString();
        }
    }
}
