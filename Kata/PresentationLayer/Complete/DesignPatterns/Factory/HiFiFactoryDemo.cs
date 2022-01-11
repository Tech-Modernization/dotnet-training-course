using System;
using System.Collections.Generic;
using System.Text;
using BusinessObjectLayer.HiFiFactory;

namespace PresentationLayer
{
    public class HiFiFactoryDemo : FactoryDemoBase<HomeStereoBase, ComponentBase>
    {
        public HiFiFactoryDemo(params HomeStereoBase[] concreteCreators) : base(concreteCreators)
        {
        }

        public override void FillExplicit(HomeStereoBase ac)
        {
            throw new NotImplementedException();
        }
    }
}
