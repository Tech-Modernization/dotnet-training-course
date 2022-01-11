using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessObjectLayer.FestivalFactory
{
    public interface IFestivalBooker
    {
        T AddVenue<T>(string name);
        T AddAct<T>(string name, int numPerformers, int estYYYY, int gigsPerYear, int repSize
            , bool signed = false, int highestChartPos = 0, int weekAtPos = 0);
        PerformanceSpace AddPerformanceSpace(string name, int capacity, int maxPerformers, int punterExitRatePerMin);
        List<PerformanceSlot> CreateSchedule(PerformanceSpace space, DateTime firstSlotTime, DateTime venueClosingTime);

        FestivalApplication Apply(ActBase act, string venueName, string spaceName
            , List<FestivalTimeSlot> preferredSlots, bool standbyWilling);
        VenueBase GetVenueByAct(ActBase act);
        PerformanceSpace GetSpaceByAct(ActBase act);

        ActBase AllocateSlot(ActBase act, PerformanceSpace space);
        int GetReputation(ActBase act);
        void Notify(FestivalApplication festApp, NotificationType notification);
        void Accept(FestivalApplication festApp);
        void Decline(FestivalApplication festApp);
        int Announce(NotificationType notification);
        void PrintItinerary(List<VenueBase> venues);
    }
}
