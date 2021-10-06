using System.Collections.Generic;

namespace DemoKata.CustomTypes
{
    public abstract class DrinkFactory
    {
        private List<DrinkBase> variants = new List<DrinkBase>();
        public List<DrinkBase> Variants
        {
            get { return variants; }
        }
        public DrinkFactory()
        {
            this.CreateVariants();
        }

        protected abstract void CreateVariants();
    }
}
