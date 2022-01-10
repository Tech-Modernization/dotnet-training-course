namespace Kata.CustomTypes.PublicationFactory
{
    public class PrintProperties
    {
        public string PropertySetName { get; set; }
        public Binding Binding { get; set; }
        public PaperFinish PaperFinish { get; set; }
        public PaperStock PaperStock { get; set; }
        public CoverWeight CoverWeight { get; set; }

        public PrintProperties(string propSetName, Binding binding, CoverWeight coverWeight, PaperStock paperStock, PaperFinish paperFinish)
        {
            PropertySetName = propSetName;
            Binding = binding;
            PaperStock = paperStock;
            PaperFinish = paperFinish;
            CoverWeight = coverWeight;
        }

        public override string ToString()
        {
            return $"{PropertySetName} => Stock: {PaperStock}, Finish: {PaperFinish}, Cover: {CoverWeight}, Binding: {Binding}";
        }
    }
}
