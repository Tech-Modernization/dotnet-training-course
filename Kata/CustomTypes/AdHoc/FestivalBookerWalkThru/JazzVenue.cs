using System;
using System.Collections.Generic;
using System.Text;

namespace Kata.CustomTypes.FestivalBookerWalkThru
{
    public class JazzVenue : VenueBase
    {
        public JazzVenue()
        {
            Genre = MusicGenre.Jazz;
            Characteristics.Add("Has a piano on stage");
        }
    }
}
