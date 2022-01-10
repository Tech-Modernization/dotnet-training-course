using System;
using System.Collections.Generic;
using System.Text;

namespace Kata.CustomTypes.FestivalFactory
{
    public interface IActProfiler
    {
        T AddAct<T>(string name, int numPerformers, int estYYYY, int gigsPerYear, int repSize
    , bool signed = false, int highestChartPos = 0, int weekAtPos = 0);
        int GetReputation(ActBase act);
    }
}
