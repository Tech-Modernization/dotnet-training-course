using System;
using System.Collections.Generic;
using System.Text;

namespace Kata.CustomTypes.PublicationFactory
{
    public class HardPress : PressBase
    {
        protected override void CreatePublications()
        {
            Publications.Add(new Hardback());
            Publications.Add(new Hardback());
        }
    }
}
