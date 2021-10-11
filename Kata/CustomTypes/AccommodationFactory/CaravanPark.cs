﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CustomTypes.AccommodationFactory
{
    public class CaravanPark : EnclosureBase
    {
        protected override void CreateUnits()
        {
            Units.Add(new CamperVan());
            Units.Add(new CamperVan());
            Units.Add(new CamperVan());
        }
    }
}
