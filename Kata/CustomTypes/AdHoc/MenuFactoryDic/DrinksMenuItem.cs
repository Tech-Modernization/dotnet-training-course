using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kata.CustomTypes.MenuFactoryDic
{
    public class DrinksMenuItem<T> : MenuItemBase<T, SizeVariant>
    {
        public DrinksMenuItem() : base()
        {
        }
        public DrinksMenuItem(T drinkVar, SizeVariant sizeVar, decimal price) : base()
        {
            Variants.AddVariant(drinkVar, sizeVar, price);
        }

        protected override void CreateVariants()
        {
            // nothing to do here cuz still too abstract at this level
        }

        public override string ToString()
        {
            if ((Variants?.Count ?? 0) == 0) return base.ToString();

            var sb = new StringBuilder();
            sb.AppendLine($"{base.Name} Sub-Menu");
            foreach(var v in Variants)
            {
                sb.AppendLine($"{v.Key} {{{v.Value:C}},10}");
            }
            return sb.ToString();
        }
    }
}
