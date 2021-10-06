using System;
using System.Collections.Generic;
using System.Text;

namespace CustomTypes.DrinkFactory
{
    public class Wine : DrinkBase
    {
        public Wine(string name, int year, decimal pricePerGlass)
        {

        }
        public Wine(string name, int year, VolumeTariffDictionary tariff)
        {

        }
    }
}
