using System;
using System.Collections.Generic;
using System.Text;

namespace Kata.CustomTypes.FestivalFactoryDone
{
    public interface IActProfiler
    {
        T AddAct<T>(string name, int numPerformers, int yearEst, int gigsPerYear, int repertoire,
            bool signed = default, int highestChartPos = default, int weeksAtPos = default);
        
        TimeSpan GetRepertoireLength(Repertoire<SongBase> songs);
        int CalculateReputation();
        int GetReputation(ActBase act);
    }
}
