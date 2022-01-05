using System;
using System.Collections.Generic;
using System.Text;

namespace Kata.CustomTypes.FestivalBookerWalkThru
{
    public class ProgRockVenue : VenueBase
    {
        public ProgRockVenue()
        {
            Genre = MusicGenre.ProgRock;
            Characteristics.Add("stuff unique to a prog rock venue");
        }
    }
}
