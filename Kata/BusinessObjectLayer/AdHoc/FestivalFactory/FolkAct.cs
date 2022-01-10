using System;
using System.Collections.Generic;
using System.Text;

namespace Kata.CustomTypes.FestivalFactoryDone
{
    public class FolkAct : ActBase
    {
        public FolkAct(string name, int yearEstablished, int gigsPerYear, int chartHigh, int weeksAtPos) 
            : base(name, yearEstablished, gigsPerYear, chartHigh = 0, weeksAtPos = 0)
        {
        }
    }
}
