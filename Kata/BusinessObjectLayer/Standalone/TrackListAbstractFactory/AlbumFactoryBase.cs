using System;
using System.Collections.Generic;

namespace BusinessObjectLayer.TrackListAbstractFactory
{
    public abstract class AlbumFactoryBase
    {
        private List<TrackListBase> tracklists = new List<TrackListBase>();
        public List<TrackListBase> TrackLists { get => tracklists;  }
        protected int Volumes;
        protected bool HasMultipleArtists;
        public AlbumFactoryBase(int numVols, bool multiArtist)
        {
            Volumes = numVols;
            HasMultipleArtists = multiArtist;
            CreateTrackLists();
        }
        protected abstract void CreateTrackLists();
    }
}
