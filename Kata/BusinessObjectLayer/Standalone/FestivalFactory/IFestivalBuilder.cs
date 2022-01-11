using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessObjectLayer.FestivalFactory
{
    public interface IFestivalBuilder
    { 
        T AddVenue<T>(string name) where T: VenueBase, new();
        int Announce(NotificationType notification);
        void PrintItinerary(List<VenueBase> venues);
        void Build();
        bool OpenToApplications();
    }
}
