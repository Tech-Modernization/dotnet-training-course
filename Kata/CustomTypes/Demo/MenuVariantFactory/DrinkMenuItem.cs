using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kata.CustomTypes.MenuFactoryListDone
{
    public class DrinkMenuItem : MenuItemBase
    {
        public DrinkMenuItem() : base()
        {
            this.CreateVariants();
        }
        public DrinkMenuItem(string name, decimal price) : base(name, price)
        {
        }
        public void AddVariant(string name, SizeVariant size, decimal price)
        {
            var possDups = Variants.Where(variant => variant is DrinkMenuItemVariant 
                                                     && variant.Name == name 
                                                     && variant.Price == price).ToList();
            if (possDups.Any(variant => ((DrinkMenuItemVariant) variant).Size == size))
            {
                Console.WriteLine($"Ignoring duplicate {Name} variant: {name}, {size}, {price:C}");
                return;
            }

            Variants.Add(new DrinkMenuItemVariant(name, price, size));
        }

        protected override void CreateVariants()
        {
            // nothing to do here
        }

        public override string ToString()
        {
            if (Variants.Count == 1) return base.ToString();

            var sb = new StringBuilder();
            sb.AppendLine($"{Name} Sub-Menu");
            foreach(var v in Variants)
            {
                sb.AppendLine(v.ToString());
            }
            return sb.ToString();
        }
    }
}
