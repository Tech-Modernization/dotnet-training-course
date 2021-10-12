using System;
using System.Collections.Generic;
using Kata.Demos;
using CustomTypes.MediaFactory;
using CustomTypes.HiFiFactory;
using Kata.CustomTypes.MenuFactoryList;
using Kata.CustomTypes.PublicationFactory;
using Kata.CustomTypes.MenuItemVariantFactory;

namespace Kata
{
    class Program
    {
        static void Main(string[] args)
        {
            var menuDemo = new MenuFactoryDemo(new DrinksMenu(), new FoodMenu());
            menuDemo.Run();
         //   var menuItemDemo = new MenuItemFactoryDemo(new DrinkMenuItem(), new FoodMenuItem());
         //   menuItemDemo.Run();
        }
    }
}
