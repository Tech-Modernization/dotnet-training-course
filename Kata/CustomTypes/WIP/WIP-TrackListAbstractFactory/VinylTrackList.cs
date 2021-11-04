using System;
using System.Collections.Generic;
using System.Text;

namespace Kata.CustomTypes.TrackListAbstractFactory
{
    public class VinylTrackList : TrackListBase
    {
        public VinylTrackList(bool multiArtist) : base(multiArtist)
        {
            Add("Side 1", new List<TrackDetail>());
            Add("Side 2", new List<TrackDetail>());
        }

        public override event GetTracks OnGetTracks;

        public override void AddTracks()
        {
            OnGetTracks(this, new EventArgs());
        }
    }
}
