using System;
using System.Collections.Generic;
using System.Text;

namespace Kata.CustomTypes.MenuFactoryList
{
    public class FoodMenuItem : MenuItemBase
    {
        protected bool IsVeganFriendly { get; set; }

        public FoodMenuItem(string name, decimal price, bool isVeganFriendly = false) : base(name, price)
        {
            IsVeganFriendly = isVeganFriendly;
        }

        protected override void CreateVariants()
        {
            // no variants at this level
        }
    }
}
