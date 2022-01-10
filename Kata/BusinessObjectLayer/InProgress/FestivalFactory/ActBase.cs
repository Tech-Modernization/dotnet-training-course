using System;
using System.Collections.Generic;
using System.Text;

namespace Kata.CustomTypes.FestivalFactory
{
    public abstract class ActBase
    {
        public string Name { get; }
        public int NumPerformers { get; }
        public int YearEstablished { get; }
        public int GigsPerYear { get; }
        public int RepertoireSize { get; }
        protected List<SongBase> Repertoire { get; }

        protected ActBase(string name, int numPerformers, int yearEstablished, 
            int gigsPerYear, int repertoireSize)
        {
            Name = name;
            NumPerformers = numPerformers;
            YearEstablished = yearEstablished;
            GigsPerYear = gigsPerYear;
            RepertoireSize = repertoireSize;
            Repertoire = new List<SongBase>();
        }

    }
}
