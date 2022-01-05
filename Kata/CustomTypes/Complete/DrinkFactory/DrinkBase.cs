using System;
using System.Collections.Generic;
using System.Text;

namespace Kata.CustomTypes.DrinkFactory
{
    public abstract class DrinkBase
    {
        // 1.  backing store for the list
        private List<DrinkVariantBase> variants = new List<DrinkVariantBase>();

        // 2.  readonly property
        public List<DrinkVariantBase> Variants { get { return variants; } }
        // 3. constructor call to factory method
        public DrinkBase()
        {
            this.CreateVariants();
        }
        // 4. factory method signature
        protected abstract void CreateVariants();
    }
}
