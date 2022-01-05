using System;
using System.Collections.Generic;
using System.Text;

namespace Kata.CustomTypes.HiFiFactory
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
