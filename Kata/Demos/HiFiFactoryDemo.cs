using System;
using System.Collections.Generic;
using System.Text;
using CustomTypes.HiFiFactory;

namespace Kata.Demos
{
    public class HiFiFactoryDemo : FactoryDemoBase<HomeStereoBase, ComponentBase>
    {
        public HiFiFactoryDemo(params HomeStereoBase[] concreteCreators) : base(concreteCreators)
        {
        }
    }
}
