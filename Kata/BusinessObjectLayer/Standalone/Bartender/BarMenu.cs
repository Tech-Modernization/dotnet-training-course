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
            Steps.Add(new BarKeyStep(1, "What can I get you? {0} or {1}: ", this, null));
            Steps.Add(new BarKeyStep(2, "{0} it is!  Do you want {0} or {1}: ", this, null));
            Steps.Add(new BarKeyStep(3, "How many {1} of {0} would you like? Enter 1 - 9: ", this, null));
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

        public MenuSelectionItemBase SelectionItem => new BarSelectionItem();

        public IEnumerator GetEnumerator()
        {
            return Steps.GetEnumerator();
        }
    }
}
