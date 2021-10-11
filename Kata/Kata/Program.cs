using System;
using System.Collections.Generic;
using Kata.Demos;
using CustomTypes.MediaFactory;
using Kata.CustomTypes.MenuFactoryList;
using Kata.CustomTypes.PublicationFactory;

namespace Kata
{
    class Program
    {
        static void Main(string[] args)
        {
            var mediaDemo = new MediaFactoryDemo(new AudioCollection(), new VideoCollection());
            // mediaDemo.Run();

            var pressDemo = new PressFactoryDemo(new HardPress(), new SoftPress());
            pressDemo.Run();

            var menuDemo = new MenuFactoryDemo(new DrinksMenu(), new FoodMenu());
            menuDemo.Run();
        }
    }
}
