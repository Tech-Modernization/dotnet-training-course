using System;
using System.Collections.Generic;
using System.Text;

namespace CustomTypes.RoomTidy
{
    public class StorageDimensions : IDimensions
    {
        public DimensionsPerspective? Perspective;
        public decimal? Length;
        public decimal? Width;
        public decimal? Height;
        public decimal? Depth;

        public StorageDimensions(DimensionsPerspective perspective)
        {
            Perspective = perspective;
        }

        public decimal? GetVolume()
        {
            if (!Perspective.HasValue) return null;

            switch(Perspective)
            {
                case DimensionsPerspective.FromTop:
                    return Depth * Length * Width;
                case DimensionsPerspective.FromFront:
                    return Depth * Height * Width;
                case DimensionsPerspective.FromBase:
                    return Length * Height * Width;
            }

            return null;
        }
    }
}
