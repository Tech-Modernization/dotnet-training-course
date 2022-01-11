using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessObjectLayer.FestivalFactory
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
