namespace Kata.CustomTypes.PublicationFactory
{
    public class FirmCover : PublicationBase
    {
        protected override void CreatePrintProperties()
        {
            Properties.Add(AddPrintProperties<PrintProperties>("Coffee table book", Binding.Gum, CoverWeight.Firm, PaperStock.B5, PaperFinish.Gloss));
        }
    }
}
