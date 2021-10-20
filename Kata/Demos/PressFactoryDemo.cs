using System;
using System.Collections.Generic;
using System.Text;
using Kata.CustomTypes.PublicationFactory;

namespace Kata.Demos
{
    public class PressFactoryDemo : FactoryDemoBase<PressBase, PublicationBase>
    {
        public PressFactoryDemo(params PressBase[] concreteCreators) : base(concreteCreators)
        {
        }

        public override void DisplayExplicit(PressBase c)
        {
            throw new NotImplementedException();
        }

        public override void DisplayImplicit(PressBase c)
        {
            throw new NotImplementedException();
        }
    }
}
