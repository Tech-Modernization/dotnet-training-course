using System;
using System.Collections.Generic;
using System.Text;

namespace CustomTypes.AccommodationFactory
{
    // abstract creator
    public abstract class EnclosureBase
    {
        // backing store
        private List<AccommodationUnitBase> units = new List<AccommodationUnitBase>();
        // property
        public List<AccommodationUnitBase> Units { get { return units; } }
        // constructor
        public EnclosureBase()
        {
            CreateUnits();
        }
        // factory method
        protected abstract void CreateUnits();
    }
}
