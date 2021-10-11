using System;
using System.Collections.Generic;
using System.Text;

namespace CustomTypes.HiFiFactory
{
    public class MiniHifi : HomeStereoBase
    {
        protected override void CreateComponents()
        {
            base.CreateComponents();
            Components.Add(new CompactDisc());
            Components.Add(new DABRadio());
            Components.Add(new TapeDeck());
        }
    }
}
