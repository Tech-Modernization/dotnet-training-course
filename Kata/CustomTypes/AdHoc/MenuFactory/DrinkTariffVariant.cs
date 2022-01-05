using System;
using System.Collections.Generic;
using System.Text;

namespace Kata.CustomTypes.MenuFactory
{
    public class DrinkTariffVariant<T1>
    {
        public SizeVariant Size;
        public T1 DrinkVariant;
        public decimal Price;

        public override string ToString()
        {
            return $"-- {DrinkVariant} ({Size})";
        }
    }
}
