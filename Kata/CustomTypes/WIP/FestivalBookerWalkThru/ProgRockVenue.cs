using System;
using System.Collections.Generic;
using System.Text;

namespace Kata.CustomTypes.WIP.FestivalBookerWalkThru
{
    public class ProgRockVenue : VenueBase
    {
        public Func<bool> IsHairLengthOkay;
        public ProgRockVenue()
        {
            Genre = MusicGenre.ProgRock;
        }
    }
}
