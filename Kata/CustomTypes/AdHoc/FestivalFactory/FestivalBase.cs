using System;
using System.Collections.Generic;
using System.Text;

namespace Kata.CustomTypes.FestivalFactoryDone
{
    public abstract class FestivalBase : IFestivalBuilder
    {
        public string Name { get; }

        public FestivalBase(string name)
        {
            this.Name = name;
        }

        public T AddVenue<T>(string name)
        {
            throw new NotImplementedException();
        }
    }
}
