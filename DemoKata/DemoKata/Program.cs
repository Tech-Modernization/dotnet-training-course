using CustomTypes.MenuFactory;
using DemoKata.Exercises;
using System;

namespace DemoKata
{
    public class Program
    {
        // https://www.dofactory.com/net/factory-method-design-pattern

        static void Main(string[] args)
        {
            // Note: constructors call Factory Method
            var menus = new MenuBase[3];
          //  menus[0] = new DrinkMenu();
            menus[1] = new DessertMenu();
         //   menus[2] = new MainMenu();

            // Display document pages
            foreach (var m in menus)
            {
                if (m is DessertMenu)
                {
                    foreach (DessertMenuItem mi in m.Items)
                    {
                        Console.WriteLine($"{mi.Name} will cost you {mi.Price:C}");
                    }

                }
            }
        }
        /*
        static void Week5()
        {
            var oi = new OrderItem(new Drink());
            //var d = oi.DrinkProperty;
            var newDrink = new Drink();
            newDrink.Name = "Squash";
            oi.Drink = newDrink;


            for (var i = 0; i < 10; i++)
            {
                var intThing = getInt();
                if (intThing.HasValue)
                {
                    Console.WriteLine($"intThing: {intThing} / {intThing.Value}");
                }
            }

            var e5 = new BooleanSort();
            var e16 = new DrinksOrder();
            DoStuff(e16);


        }
        static int? getInt()
        {
            var rand = new Random();
            int? next = rand.Next(-100, 100);
            return next % 2 == 0 ? null : next;
        }

        static void DoStuff(IExercise iface)
        {
            iface.Run();
        }
        */
    }
}
