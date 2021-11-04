using System;
using System.Collections.Generic;
using System.Text;

namespace Kata.CustomTypes.PublicationFactory
{
    public class Comic : PublicationBase
    {
        protected override void CreatePrintProperties()
        {
            Properties.Add(AddPrintProperties<PrintProperties>("Comic", Binding.Staple, CoverWeight.Soft, PaperStock.A4, PaperFinish.Matt));
        }
    }
}
