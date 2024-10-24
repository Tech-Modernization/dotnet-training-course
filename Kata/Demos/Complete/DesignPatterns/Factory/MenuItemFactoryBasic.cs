﻿using System;
using System.Collections.Generic;
using System.Text;
using Kata.CustomTypes.MenuFactoryList;

namespace Kata.Demos
{
    public class MenuItemFactoryBasic : DemoBase
    { 
        public void Run()
        {
            var creators = new MenuBase[2];
            creators[0] = new DrinksMenu();
            creators[1] = new FoodMenu();
            foreach (var creator in creators)
            {
                Console.WriteLine(creator);
                foreach (var product in creator.Items)
                {
                    Console.WriteLine($"   {product}");
                }
            }
        }
    }
}
