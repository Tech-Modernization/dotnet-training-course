using System;
using System.Collections.Generic;
using System.Text;

using BusinessObjectLayer.OfficeDistractions;

namespace PresentationLayer
{
    public class DistractionKata : DemoBase
    {
        public override void Run()
        {
            //AddPart(Part1, "Distractions with dependency inversion violations");
            AddPart(Part2, "Resolve DIP violations and behold the paradise!");
            base.Run();
        }

        public void Part1()
        {
            var office = new Office();
            office.BusinessAsUsual();
        }
        public void Part2()
        {
            var office = new Office(new SandwichTrolley(), new IceCreamVan());
            office.BusinessAsUsual();
        }
    }
}
