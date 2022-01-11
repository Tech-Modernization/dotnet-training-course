using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessObjectLayer.TrackListAbstractFactory
{
    public class VinylAlbum : AlbumFactoryBase
    {
        public VinylAlbum(int numVols) : base(numVols, false)
        {
        }

        protected override void CreateTrackLists()
        {
            for (var i = Volumes; i > 0; i--)
                TrackLists.Add(new VinylTrackList(HasMultipleArtists));
        }
    }
}
