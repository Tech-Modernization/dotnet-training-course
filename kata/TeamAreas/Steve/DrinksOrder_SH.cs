using DemoKata.CustomTypes;
using System;

namespace DemoKata.Exercises
{
    public class DrinksOrder_SH : IExercise
    {
        public void Run()
        {
            var done = false;
            var order = new Order();

            DrinksMenu drinksMenu = new DrinksMenu();
            drinksMenu.Update(new Coffee());
            drinksMenu.Update(new Tea());
            drinksMenu.Update(new Beer());
            drinksMenu.Update(new Wine());

            // Thurday - move order.add into drinksMenu and 
            // change loop to do while(GetSelection = true)


            do
            {
                drinksMenu.Display();
                //var index = drinksMenu.GetSelection(order);

                //if (index == 5) break;

                //order.Add(drinksMenu.MenuItem(index - 1));
            } while (drinksMenu.GetSelection(order));

            Console.WriteLine(order);

        }
    }
}
