using System;
using System.Collections.Generic;
using System.Text;

namespace Kata.CustomTypes.FestivalFactory
{
    public class FolkAct : ActBase
    {
        public FolkAct(string name, int numPerformers, int yearEstablished, int gigsPerYear, 
            int repertoireSize) 
            : base(name, numPerformers,yearEstablished, gigsPerYear, repertoireSize)
        {
        }
    }
}
