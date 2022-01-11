namespace BusinessObjectLayer.PublicationFactory
{
    public class Hardback : PublicationBase
    {
        private bool hasDustJacket;
        public Hardback(bool hasDustJacket = false) : base(false)
        {
            this.hasDustJacket = hasDustJacket;
            CreatePrintProperties();
        }
        public override T AddPrintProperties<T>(string propSetName, Binding binding, CoverWeight coverWeight, PaperStock paperStock, PaperFinish paperFinish)
        {
            return new HardbackPrintProperties(propSetName, binding, coverWeight, paperStock, paperFinish, hasDustJacket) as T;
        }

        protected override void CreatePrintProperties()
        {
            Properties.Add(AddPrintProperties<PrintProperties>("Large sketch pad", Binding.Spiral, CoverWeight.Hard, PaperStock.A3, PaperFinish.Matt));
            Properties.Add(AddPrintProperties<PrintProperties>("Regular sketch pad", Binding.Spiral, CoverWeight.Hard, PaperStock.A4, PaperFinish.Matt));
            Properties.Add(AddPrintProperties<PrintProperties>("Wide sketch pad", Binding.Spiral, CoverWeight.Hard, PaperStock.B4, PaperFinish.Matt));
            Properties.Add(AddPrintProperties<PrintProperties>("Novel", Binding.Cord, CoverWeight.Hard, PaperStock.A5, PaperFinish.Matt));
            Properties.Add(AddPrintProperties<PrintProperties>("Technical Manual", Binding.Cord, CoverWeight.Hard, PaperStock.A5, PaperFinish.Matt));
            Properties.Add(AddPrintProperties<PrintProperties>("Dictionary", Binding.Cord, CoverWeight.Hard, PaperStock.A5, PaperFinish.Matt));
            Properties.Add(AddPrintProperties<PrintProperties>("Large diary", Binding.Spiral, CoverWeight.Hard, PaperStock.A4, PaperFinish.Matt));
            Properties.Add(AddPrintProperties<PrintProperties>("Pocket diary", Binding.Spiral, CoverWeight.Hard, PaperStock.A6, PaperFinish.Matt));
            Properties.Add(AddPrintProperties<PrintProperties>("Cookery book", Binding.Spiral, CoverWeight.Hard, PaperStock.B5, PaperFinish.Gloss));
        }
    }
}
