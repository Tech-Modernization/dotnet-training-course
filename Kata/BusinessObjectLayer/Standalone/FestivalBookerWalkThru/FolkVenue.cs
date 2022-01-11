using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessObjectLayer.FestivalBookerWalkThru
{
    public class FolkVenue : VenueBase
    {
        public List<string> DonationsTrough;
        public List<string> VeganSignage;

        public FolkVenue()
        {
            Genre = MusicGenre.Folk;
            Characteristics.Add("Something cool about a folk venue");
        }
    }
}
