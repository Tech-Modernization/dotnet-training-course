using System;
using System.Collections.Generic;
using System.Text;

namespace Kata.CustomTypes.MenuFactory
{
    public class DrinksMenu : MenuBase
    {
        protected override void CreateMenuItems()
        {
            Items.Add(new DrinkMenuItem("Coffee", 4.0M));
            Items.Add(new DrinkMenuItem("Tea", 2.5M));
            Items.Add(new DrinkMenuItem("Beer", 4.5M));
            Items.Add(new DrinkMenuItem("Wine", 6.0M));
        }
    }
}
