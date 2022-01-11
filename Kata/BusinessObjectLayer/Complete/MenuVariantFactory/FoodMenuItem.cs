using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessObjectLayer.MenuFactoryListDone
{
    public class FoodMenuItem : MenuItemBase
    {
        public FoodMenuItem(string name, decimal price) : base(name, price)
        {
        }

        protected override void CreateVariants()
        {
            // nothing to do here
        }
    }
}
