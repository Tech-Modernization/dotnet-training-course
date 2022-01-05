using Kata.CustomTypes.Demo.Distractions;

namespace Kata.Demos
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