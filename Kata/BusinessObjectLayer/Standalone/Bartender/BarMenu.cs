using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Helpers;
using System.Collections;

namespace BusinessObjectLayer.Bartender
{
    // Responsibility: define the contents of a menu
    // TODO:
    //    -- get stock from file
    //    -- introduce stock level so menu doesn't display out of stock items
    // 
    public class BarMenu : IMenu
    {
        protected List<Drink> Stock { get; }
        protected List<BarKeyStep> Steps { get; }
        public List<TariffItem> Tariff { get; }
        public List<string> ItemNames => Stock.Select(item => item.Name).ToList();

        public BarMenu()
        {
            Stock = new List<Drink>()
            {
                // shortcut for:
                //    new Drink("name", new List<DrinkMeasure>() {DrinkMeasure.Pint, etc})

                new Drink("Spirit", new []{DrinkMeasure.Shot, DrinkMeasure.Single, DrinkMeasure.Double}.ToList()),
                new Drink("Beer", new []{DrinkMeasure.Half, DrinkMeasure.Pint}.ToList()),
                new Drink("Wine", new []{DrinkMeasure.Small, DrinkMeasure.Large}.ToList())
            };
            Tariff = new List<TariffItem>();
            LoadMenu();

            Steps = new List<BarKeyStep>();
            LoadSteps();
        }

        private void LoadSteps()
        {
            Steps.Add(new BarKeyStep(1, "What can I get you? {0} or {1}: ", this, MapKeyToDrink));
            Steps.Add(new BarKeyStep(2, "{0} it is!  Do you want {1} or {2}: ", this, MapKeyToMeasure));
            Steps.Add(new BarKeyStep(3, "How many {0} of {1} would you like? Enter 1 - 9: ", this, MapKeyToQuantity));
        }

        private void LoadMenu()
        {
            var basePrice = 1.0M;
            var increment = 2M;
            var menuWidth = 50;
            foreach (var d in Stock)
            {
                var price = basePrice;
                foreach (var m in d.Measures)
                {
                    var text = $"{d.Name} ({m})";
                    Tariff.Add(new TariffItem(text, price, menuWidth));
                    price *= increment;
                }
                basePrice *= increment;
            }            
        }

        public void Display()
        {
            foreach(var tariffItem in Tariff)
            {
                Console.WriteLine(tariffItem);
            }
        }

        private BarSelectionItem selItem = new BarSelectionItem();
        public MenuSelectionItemBase SelectionItem => selItem;

        public IEnumerator GetEnumerator()
        {
            return Steps.GetEnumerator();
        }

        private void MapKeyToDrink(ConsoleKey key, int index)
        {
            var drink = Stock.SingleOrDefault(item => item.Name[0] == (char)key);
            if (drink != null)
            {
                selItem.Stock = drink;
            }
        }

        private void MapKeyToMeasure(ConsoleKey key, int index)
        {
            var measure = selItem.Stock.Measures.SingleOrDefault(m => m.ToString()[0] == (char)key);
            if (measure != DrinkMeasure.None)
            {
                selItem.Measure = measure;
            }
        }

        private void MapKeyToQuantity(ConsoleKey key, int index)
        {
            selItem.Quantity = (int)key - 48;
        }
    }
}
