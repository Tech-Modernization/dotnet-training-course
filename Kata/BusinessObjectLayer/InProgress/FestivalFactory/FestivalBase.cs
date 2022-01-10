using System;
using System.Collections.Generic;
using System.Text;

namespace Kata.CustomTypes.FestivalFactory
{
    public abstract class FestivalBase : IFestivalBuilder, IApplicationManager
    {

        protected List<VenueBase> Venues { get; }

        protected DateTime FestivalStartDate { get; }
        protected DateTime FestivalEndDate { get; }
        protected DateTime ApplicationsOpenDate { get; }
        protected DateTime ApplicationsCloseDate { get; }

        public FestivalBase()
        {
            Venues = new List<VenueBase>();
        }

        public int Announce(NotificationType notification)
        {
            throw new NotImplementedException();
        }

        public void PrintItinerary(List<VenueBase> venues)
        {
            throw new NotImplementedException();
        }

        public void Build()
        {
            throw new NotImplementedException();
        }

        public bool OpenToApplications()
        {
            var now = DateTime.Now;
            return now >= ApplicationsOpenDate && now <= ApplicationsCloseDate;
        }

        public T AddVenue<T>(string name) where T : VenueBase, new()
        {
            var newVenue = new T();
            Venues.Add(newVenue);
            return newVenue;
        }

        public FestivalApplication Apply(ActBase act, string venueName, string spaceName,
            List<int> preferredDays, List<TimeSlot> preferredSlots, bool standbyWilling)
        {
            return new FestivalApplication()
            {
                Act = act,
                PreferredVenueName = venueName,
                PreferredPerformanceSpace = spaceName,
                PreferredDays = preferredDays,
                PreferredSlots = preferredSlots,
                StandbyWilling = standbyWilling
            };
        }

        public VenueBase GetVenueByAct(ActBase act)
        {
            throw new NotImplementedException();
        }

        public void Notify(FestivalApplication festApp, NotificationType notification)
        {
            throw new NotImplementedException();
        }

        public void Accept(FestivalApplication festApp)
        {
            throw new NotImplementedException();
        }

        public void Decline(FestivalApplication festApp)
        {
            throw new NotImplementedException();
        }
    }
}
