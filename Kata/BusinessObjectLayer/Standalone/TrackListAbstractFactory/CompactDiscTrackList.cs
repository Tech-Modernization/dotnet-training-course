using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessObjectLayer.TrackListAbstractFactory
{
    public class CompactDiscTrackList : TrackListBase
    {
        public CompactDiscTrackList(bool multiArtist) :base(multiArtist)
        {
            Add("CD", new List<TrackDetail>());
        }

        public override event GetTracks OnGetTracks;

        public override void AddTracks()
        {
            OnGetTracks(this, new EventArgs());
        }
    }
}
