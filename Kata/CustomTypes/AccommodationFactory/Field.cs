using System;
using System.Collections.Generic;
using System.Text;

namespace CustomTypes.AccommodationFactory
{
    public class Field : EnclosureBase
    {
        protected override void CreateUnits()
        {
            Units.Add(new Tent());
            Units.Add(new Tent());
            Units.Add(new CamperVan());
        }
    }
}
