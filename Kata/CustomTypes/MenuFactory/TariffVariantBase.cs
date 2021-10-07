using System;
using System.Collections.Generic;
using System.Text;

namespace Kata.CustomTypes.MenuFactory
{
    public abstract class TariffVariantBase<TVariant1, TVariant2> 
    {
        public TVariant1 Variant1;
        public TVariant2 Variant2;

        public override string ToString()
        {
            return $"-- {Variant1} ({Variant2})";
        }
        
    }
}

