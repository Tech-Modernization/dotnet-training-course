using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace BusinessObjectLayer.Bartender
{
    public class Menu
    {
        protected List<Drink> stock;
        public List<MenuItem> tariff;

        public Menu()
        {
            stock = new List<Drink>()
            {
                // shortcut for:
                //    new Drink("name", new List<DrinkMeasure>() {DrinkMeasure.Pint, etc})

                new Drink("Beer", new []{DrinkMeasure.Half, DrinkMeasure.Pint}.ToList()),
                new Drink("Wine", new []{DrinkMeasure.Small, DrinkMeasure.Large}.ToList()),
                new Drink("Spirit", new []{DrinkMeasure.Shot, DrinkMeasure.Single, DrinkMeasure.Double}.ToList())
            };

            LoadMenu();
        }

        private void LoadMenu()
        {
            tariff = new List<MenuItem>();
            tariff.Add(new MenuItem("Half pint beer", DrinkMeasure.Half, 2.5M));
            tariff.Add(new MenuItem("Pint beer", DrinkMeasure.Pint, 5M));
            tariff.Add(new MenuItem("Small glass of wine", DrinkMeasure.Small, 3.0M));
            tariff.Add(new MenuItem("Large glass of wine", DrinkMeasure.Large, 6M));
            tariff.Add(new MenuItem("Shot of a spirit", DrinkMeasure.Shot, 1.75M));
            tariff.Add(new MenuItem("Single spirit", DrinkMeasure.Single, 2.25M));
            tariff.Add(new MenuItem("Double spirit", DrinkMeasure.Double, 4.5M));
        }

        public void Display()
        {
            foreach(var drink in tariff)
            {
                Console.WriteLine($"{drink.Text}......{drink.Price:C}");
            }
        }
    }
}
