using DemoKata.CustomTypes;
using System.Collections.Generic;

namespace CustomTypes.MenuFactory
{
    public class DrinkMenuItem : MenuItemBase
    {
        private DrinkBase drink;
        public bool AlcoholFree
        {
            get
            {
                return new List<DrinkType>() { DrinkType.Wine, DrinkType.Beer }.Contains(drink.DrinkType);
            }
        }

        public DrinkMenuItem(DrinkBase drink)
        {

        }
    }
}
