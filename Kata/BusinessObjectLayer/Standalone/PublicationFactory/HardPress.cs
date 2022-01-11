using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessObjectLayer.PublicationFactory
{
    public class HardPress : PressBase
    {
        protected override void CreatePublications()
        {
            Publications.Add(new Hardback(true));
            Publications.Add(new Hardback());
        }
    }
}
