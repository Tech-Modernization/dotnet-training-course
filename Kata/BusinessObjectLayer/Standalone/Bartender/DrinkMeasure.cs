using System;
using System.Collections.Generic;
using System.Text;

// the possible measures are half, pint, shot, double, single, small, large
// and we know these are of unrelated numeric values as far as volume of liquid
// is concerned.  so, really, we just need to group the measure terminology 
// together and assign arbitrary values to identify what's being ordered.
//
// whenever that situation arises.  Enum is the answer.

namespace BusinessObjectLayer.Bartender
{
    public enum DrinkMeasure
    {
        None,
        Half,
        Pint,
        Small,
        Large,
        Shot,
        Single,
        Double
    }
}
