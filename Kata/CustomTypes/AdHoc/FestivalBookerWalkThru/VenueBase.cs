using System;
using System.Collections.Generic;
using System.Text;

namespace Kata.CustomTypes.FestivalBookerWalkThru
{
    public abstract class VenueBase
    {
        public MusicGenre Genre;
        public string Name;
        public List<Act> Acts;
        public List<PerformanceSpace> Spaces;
        public List<string> Characteristics = new List<string>();
    }
}
