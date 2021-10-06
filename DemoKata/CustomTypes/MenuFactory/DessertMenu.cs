using System;
using System.Collections.Generic;
using System.Text;

namespace CustomTypes.MenuFactory
{
    public class DessertMenu : MenuBase
    {
        protected override void CreateMenuItems()
        {
            Items.Add(new DessertMenuItem("Ice Cream", 2.5M));
            Items.Add(new DessertMenuItem("Pudding", 3.0M));
            Items.Add(new DessertMenuItem("Torte", 6.5M));
        }
    }
}
