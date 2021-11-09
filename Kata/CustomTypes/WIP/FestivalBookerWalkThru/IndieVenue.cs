using System;
using System.Collections.Generic;
using System.Text;

namespace Kata.CustomTypes.WIP.FestivalBookerWalkThru
{
    public class IndieVenue : VenueBase
    {
        public bool ChickenWireScreenIsDown;
        public IndieVenue()
        {
            Genre = MusicGenre.Indie;
        }
    }
}
