using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessObjectLayer.PublicationFactory
{
    public class HardbackPrintProperties : PrintProperties
    {
        public bool HasDustJacket { get; set; }
        public HardbackPrintProperties(string propSetName, Binding binding, CoverWeight coverWeight, PaperStock paperStock, PaperFinish paperFinish,
            bool hasDustJacket) : base(propSetName, binding, CoverWeight.Hard, paperStock, paperFinish)
        {
            HasDustJacket = hasDustJacket;
        }

        public override string ToString()
        {
            return $"{base.ToString()}, Dust Jacket: {(HasDustJacket ? "Yes" : "No")}";
        }
    }
}
