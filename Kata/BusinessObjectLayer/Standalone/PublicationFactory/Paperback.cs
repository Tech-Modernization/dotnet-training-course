using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessObjectLayer.PublicationFactory
{
    public class Paperback : PublicationBase
    {
        protected override void CreatePrintProperties()
        {
            Properties.Add(AddPrintProperties<PrintProperties>("Standard paperback", Binding.Gum, CoverWeight.Soft, PaperStock.A5, PaperFinish.Matt));
        }
    }
}
