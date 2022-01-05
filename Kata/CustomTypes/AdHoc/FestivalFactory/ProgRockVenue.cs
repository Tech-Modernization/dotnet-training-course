using System;
using System.Collections.Generic;
using System.Text;

namespace Kata.CustomTypes.FestivalFactoryDone
{
    public class ProgRockVenue : VenueBase
    {
        public ProgRockVenue(string name) : base(name)
        {
        }

        public override void CreateSpaces()
        {
            throw new NotImplementedException();
        }
    }
}
