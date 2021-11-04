using System;
using System.Collections.Generic;
using System.Text;

namespace Kata.CustomTypes.FestivalFactory
{
    public abstract class VenueBase
    {
        public string Name { get; }
        protected List<ActBase> Acts { get; }
        protected List<PerformanceSpace> Spaces { get; }
        public VenueBase(string name)
        {
            Name = name;
            Acts = new List<ActBase>();
            Spaces = new List<PerformanceSpace>();
        }

        protected abstract void CreateSpaces();
    }
}
