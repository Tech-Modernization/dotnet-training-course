using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Kata.CustomTypes.FestivalFactoryDone
{
    public abstract class ActBase : IActProfiler
    {
        private List<SongBase> repertoire = new List<SongBase>();
        protected List<SongBase> Repertoire => repertoire;
        protected ActBase(string name, int yearEstablished, int gigsPerYear, int chartHigh, int weeksAtPos)
        {
            Name = name;
            Reputation = CalculateReputation();
            YearEstablished = yearEstablished;
            GigsPerYear = gigsPerYear;
            MostSuccessfulRelease = new Release(chartHigh, weeksAtPos);
        }

        protected string Name { get; }
        protected int Reputation { get; }
        protected int YearEstablished { get; }
        protected int GigsPerYear { get; }

        protected struct Release
        {
            public int HighestChartPosition;
            public int WeeksAtPosition;

            public Release(int highestChartPosition, int weeksAtPosition)
            {
                HighestChartPosition = highestChartPosition;
                WeeksAtPosition = weeksAtPosition;
            }
        }
        protected Release MostSuccessfulRelease { get; }
        public TimeSpan GetRepertoireLength(Repertoire<SongBase> songs)
        {
            return new TimeSpan(0, 0, 
                songs
                .Select(s => s.Key.AverageDuration)
                .Sum(dur => (int) dur.TotalMinutes));
        }

        public int CalculateReputation()
        {
            return (DateTime.Now.Year - YearEstablished)
                * GigsPerYear 
                + 
                (100 + (MostSuccessfulRelease.WeeksAtPosition 
                * (-1 * MostSuccessfulRelease.HighestChartPosition))); 
        }

        public T AddAct<T>(string name, int numPerformers, int yearEst, int gigsPerYear, int repertoire, bool signed = false, int highestChartPos = 0, int weeksAtPos = 0)
        {
            throw new NotImplementedException();
        }

        public int GetReputation(ActBase act)
        {
            throw new NotImplementedException();
        }
    }
}
