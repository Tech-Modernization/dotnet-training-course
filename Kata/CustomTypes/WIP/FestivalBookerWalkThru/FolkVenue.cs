using System;
using System.Collections.Generic;
using System.Text;

namespace Kata.CustomTypes.WIP.FestivalBookerWalkThru
{
    public class FolkVenue : VenueBase
    {
        public List<string> DonationsTrough;
        public List<string> VeganSignage;

        public FolkVenue()
        {
            Genre = MusicGenre.Folk;
        }
    }
}
