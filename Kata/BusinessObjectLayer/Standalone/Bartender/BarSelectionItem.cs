using System;
using Helpers;

namespace BusinessObjectLayer.Bartender
{
    public class BarSelectionItem : MenuSelectionItemBase
    {
        public Drink Stock; 
        public DrinkMeasure Measure;
        public int Quantity;

        public override bool IsComplete => Stock != null && Measure != DrinkMeasure.None && Quantity > 0;

        public override string ToString()
        {
            return IsComplete ? $"{Quantity} x {Measure} of {Stock.Name}" : "Selection was incomplete";
        }
    }
}