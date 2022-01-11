using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessObjectLayer.HiFiFactory
{
    public class Separates : HomeStereoBase
    {
        protected override void CreateComponents()
        {
            base.CreateComponents();
            Components.Add(new Turntable());
        }
    }
}
