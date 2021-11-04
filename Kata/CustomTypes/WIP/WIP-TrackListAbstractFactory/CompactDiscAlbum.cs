using System;

namespace Kata.CustomTypes.TrackListAbstractFactory
{
    public class CompactDiscAlbum : AlbumFactoryBase
    {
        public CompactDiscAlbum(int numVols, bool multiArtist) : base(numVols, multiArtist)
        {
        }

        protected override void CreateTrackLists()
        {
            for (var i = Volumes; i > 0; i--)
                TrackLists.Add(new CompactDiscTrackList(HasMultipleArtists));
        }
    }
}
