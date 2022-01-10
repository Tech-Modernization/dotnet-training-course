using System;
using System.Collections.Generic;
using System.Text;

namespace Kata.CustomTypes.FestivalFactory
{
    public class ProgRockAct : ActBase
    {
        public ProgRockAct(string name, int numPerformers, int yearEstablished, int gigsPerYear, int repertoireSize) 
            : base(name, numPerformers, yearEstablished, gigsPerYear, repertoireSize)
        {
        }
    }
}
