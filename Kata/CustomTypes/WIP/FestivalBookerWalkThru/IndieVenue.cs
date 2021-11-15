using System;
using System.Collections.Generic;
using System.Text;

namespace Kata.CustomTypes.FestivalBookerWalkThru
{
    public class IndieVenue : VenueBase
    {
        public bool ChickenWireScreenIsDown;
        public IndieVenue()
        {
            Genre = MusicGenre.Indie;
            Characteristics.Add("Something cool about an indie venue");
        }
    }
}
