using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Helpers;

namespace BusinessObjectLayer.Bartender
{
    // Responsibility: define the contents of a menu
    // TODO:
    //    -- get stock from file
    //    -- introduce stock level so menu doesn't display out of stock items
    // 
    public class Menu : IMenu
    {
        protected List<Drink> stock;
        public List<MenuItem> tariff;

        public Menu()
        {
            stock = new List<Drink>()
            {
                // shortcut for:
                //    new Drink("name", new List<DrinkMeasure>() {DrinkMeasure.Pint, etc})

                new Drink("Spirit", new []{DrinkMeasure.Shot, DrinkMeasure.Single, DrinkMeasure.Double}.ToList()),
                new Drink("Beer", new []{DrinkMeasure.Half, DrinkMeasure.Pint}.ToList()),
                new Drink("Wine", new []{DrinkMeasure.Small, DrinkMeasure.Large}.ToList())
            };

            LoadMenu();
        }

        private void LoadMenu()
        {
            tariff = new List<MenuItem>();
            var basePrice = 1.0M;
            var increment = 2M;

            foreach(var d in stock)
            {
                var price = basePrice;
                foreach (var m in d.Measures)
                {
                    var text = $"{d.Name} ({m})";
                    tariff.Add(new MenuItem(text, price));
                    price *= increment;
                }
                basePrice *= increment;
            }            
        }

        public void Display()
        {
            var menuWidth = 50;
            foreach(var drink in tariff)
            {
                var price = $"{drink.Price:C}";
                var dots = new string('.', menuWidth - drink.Text.Length - price.Length);
                Console.WriteLine($"{drink.Text}{dots}{price}");
            }
        }

        public HelperMenuItems GetItems()
        {
            var items = new HelperMenuItems();
            foreach(var item in tariff)
            {
                items.Add(item.Text);
            }
            return items;
        }
    }
}
