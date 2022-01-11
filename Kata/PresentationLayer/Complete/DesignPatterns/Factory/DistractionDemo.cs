using BusinessObjectLayer.Demo.Distractions;

namespace PresentationLayer
{
    public class DistractionDemo : DemoBase
    {
        public override void Run()
        {
            var office = new Office(new SandwichTrolley(), new IceCreamVan());
            office.BusinessAsUsual();
        }
    }
}