using System;
using System.Collections.Generic;
using System.Text;

namespace Kata.CustomTypes.PublicationFactory
{
    public class SoftPress : PressBase
    {
        protected override void CreatePublications()
        {
            Publications.Add(new Paperback());
            Publications.Add(new FirmCover());
            Publications.Add(new Magazine());
            Publications.Add(new Comic());
        }
    }
}
