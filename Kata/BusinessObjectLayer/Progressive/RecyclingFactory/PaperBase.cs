using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessObjectLayer.RecyclingFactory
{
    public class PaperBase : MaterialBase
    {
        public PaperBase()
        {
        }

        public PaperBase(string name) : base(name)
        {
        }
    }
}
