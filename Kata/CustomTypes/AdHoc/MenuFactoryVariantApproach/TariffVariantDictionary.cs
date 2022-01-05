using System;
using System.Collections.Generic;
using System.Text;
using Kata.CustomTypes.MenuFactoryVariant;

namespace Kata.CustomTypes.MenuFactoryVariant
{
    public class TariffVariantDictionary<T1> : Dictionary<DrinkTariffVariant<T1>, decimal> 
    {
    }
}
