using System.Collections.Generic;
using System.Text;

namespace BusinessObjectLayer.PublicationFactory
{
    public abstract class PublicationBase 
    {
        private List<PrintProperties> properties = new List<PrintProperties>();
        public List<PrintProperties> Properties => properties;
        public PublicationBase() : this(true)
        {
        }
        protected PublicationBase(bool createProperties)
        {
            if (createProperties) CreatePrintProperties();
        }
        protected abstract void CreatePrintProperties();

        public virtual T AddPrintProperties<T>(string propSetName, Binding binding, CoverWeight coverWeight, PaperStock paperStock, PaperFinish paperFinish)
            where T: PrintProperties
        {
            return (T) new PrintProperties(propSetName, binding, coverWeight, paperStock, paperFinish);
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"*** {GetType()}\nFormats available:");
            foreach(var p in Properties)
            {
                sb.AppendLine($"    {p}");
            }
            return sb.ToString();
        }
    }
}
