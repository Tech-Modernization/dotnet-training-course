using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessObjectLayer.Bartender
{
    public class Drink
    {
        public string Name { get; }

        // all the measures are in one big group.  what problem might that indicate?
        // we need to assign some kind of compatibility between the drink and the measure.
        public List<DrinkMeasure> Measures { get; }

        // next thinking step is to provide the values for these data items
        // we know that these are gonna be fixed, so we can just instantiate the class
        // and pass in the values to each one thru the constructor...
        public Drink(string name, List<DrinkMeasure> measures)
        {
            Name = name;
            Measures = measures;
        }
    }
}
