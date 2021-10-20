using System;
using System.Collections.Generic;
using System.Text;
using Kata.CustomTypes.HiFiFactory;

namespace Kata.Demos
{
    public class HiFiFactoryDemo : FactoryDemoBase<HomeStereoBase, ComponentBase>
    {
        public HiFiFactoryDemo(params HomeStereoBase[] concreteCreators) : base(concreteCreators)
        {
        }

        public override void DisplayExplicit(HomeStereoBase c)
        {
            throw new NotImplementedException();
        }

        public override void DisplayImplicit(HomeStereoBase c)
        {
            throw new NotImplementedException();
        }
    }
}
