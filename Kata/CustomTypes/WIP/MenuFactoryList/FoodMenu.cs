using System;
using System.Collections.Generic;
using System.Text;

namespace Kata.CustomTypes.MenuFactoryList
{
    public class FoodMenu : MenuBase
    {
        public FoodMenu() : base("Food")
        { }
        protected override void CreateMenuItems()
        {
            Items.Add(new FoodMenuItem("Fish n Chips", 5M));
            Items.Add(new FoodMenuItem("Pie n Chips", 4.5M));
            Items.Add(new FoodMenuItem("Faggots, pease, chips & gravy", 4.25M));
        }
    }
}
