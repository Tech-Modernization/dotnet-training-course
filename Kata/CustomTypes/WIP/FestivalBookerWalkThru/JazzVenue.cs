using System;
using System.Collections.Generic;
using System.Text;

namespace Kata.CustomTypes.WIP.FestivalBookerWalkThru
{
    public class JazzVenue : VenueBase
    {
        public Action StageAccess;
        public JazzVenue()
        {
            Genre = MusicGenre.Jazz;
        }
    }
}
