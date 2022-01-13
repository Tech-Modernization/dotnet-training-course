using Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessObjectLayer.Bartender
{
    public class DrinkMenuSelectionItem : MenuSelectionItem
    {
        public int Index { get; }
        public Drink Drink { get; }
        public DrinkMeasure Measure { get; }
        public int Quantity { get; }
        public DrinkMenuSelectionItem(int index, Drink drink, DrinkMeasure measure, int quantity) : base(index, drink.Name, quantity)
        {
            Index = index;
            Drink = drink;
            Measure = measure;
            Quantity = quantity;
        }

    }
}
