using System;
using System.Collections.Generic;
using Kata.Demos;
using Kata.CustomTypes.MenuFactoryList;

namespace Kata
{
    class Program
    {
        static void Main(string[] args)
        {
            // comment these in and out as you see fit...:-)
            //Demos.AccomondationFactoryDemo.Run();
            //Demos.HiFiFactoryDemo.Run();
            //Demos.MediaFactoryDemo.Run();
            //Demos.MenuItemFactoryDemo.Run();
            //  var bookshopDemo = new BookshopDemo();
            //  bookshopDemo.Run();
     
            var menuDemo = new MenuFactoryDemo();
            menuDemo.Run();

           /* var menu = new DrinksMenu();
            foreach (var menuItem in menu.Items)
            {
                Console.WriteLine(menuItem);
            }
           */
        }
    }
}
