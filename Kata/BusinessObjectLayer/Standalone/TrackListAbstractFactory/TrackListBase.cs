using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessObjectLayer.TrackListAbstractFactory
{
    public abstract class TrackListBase : Dictionary<string, List<TrackDetail>>
    {
        public delegate void GetTracks(TrackListBase sender, EventArgs args);
        public abstract event GetTracks OnGetTracks;

        protected bool MultipleArtists;
        public TrackListBase(bool multiArtist)
        {
            MultipleArtists = multiArtist;
            this.AddTracks();
        }

        public abstract void AddTracks();
        public virtual void Add(string listName, string title, string artist = null, TimeSpan runningTime = default)
        {
            if (ContainsKey(listName))
            {
                this[listName].Add(new TrackDetail() { Artist = MultipleArtists ? artist : null, Title = title, Duration = runningTime });
            }
        }
    }
}
