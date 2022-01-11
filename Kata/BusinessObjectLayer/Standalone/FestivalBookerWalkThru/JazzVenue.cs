using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessObjectLayer.FestivalBookerWalkThru
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
