﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessObjectLayer.FestivalFactory
{
    public class IndieAct : ActBase
    {
        public IndieAct(string name, int numPerformers, int yearEstablished, 
            int gigsPerYear, int repertoireSize) 
            : base(name, numPerformers,
                  yearEstablished, gigsPerYear,
                  repertoireSize)
        {
        }
    }
}
