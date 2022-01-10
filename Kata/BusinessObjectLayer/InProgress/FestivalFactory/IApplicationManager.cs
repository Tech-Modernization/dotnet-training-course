using System;
using System.Collections.Generic;
using System.Text;

namespace Kata.CustomTypes.FestivalFactory
{
    public interface IApplicationManager
    {
        FestivalApplication Apply(ActBase act, string venueName, string spaceName
    , List<int> preferredDays, List<TimeSlot> preferredSlots, bool standbyWilling);
        VenueBase GetVenueByAct(ActBase act);
        void Notify(FestivalApplication festApp, NotificationType notification);
        void Accept(FestivalApplication festApp);
        void Decline(FestivalApplication festApp);
    }
}
