using System;
using System.Collections.Generic;
using System.Text;
using Kata.CustomTypes.MenuFactory;

namespace Kata.CustomTypes.MenuFactory
{
    public class TariffVariantDictionary<T1> : Dictionary<DrinkTariffVariant<T1>, decimal> 
    {
    }
}
