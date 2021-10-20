using System;
using System.Collections.Generic;
using System.Text;

namespace Kata.CustomTypes.FestivalFactory
{
    public abstract class VenueBase
    {
        private List<ActBase> acts = new List<ActBase>();
        public List<ActBase> Acts => acts;
        public VenueBase()
        {
            CreateActs();
        }
        protected abstract void CreateActs();
    }
}
