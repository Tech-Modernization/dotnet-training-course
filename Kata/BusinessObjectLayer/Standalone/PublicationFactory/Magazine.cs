using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessObjectLayer.PublicationFactory
{
    public class Magazine : PublicationBase 
    {
        protected override void CreatePrintProperties()
        {
            Properties.Add(AddPrintProperties<PrintProperties>("Periodical", Binding.Gum, CoverWeight.Soft, PaperStock.A4, PaperFinish.Gloss));
        }
    }
}
