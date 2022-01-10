using System;
using System.Collections.Generic;
using System.Text;

namespace Kata.CustomTypes.RecyclingFactory
{
    public class PlasticBase : MaterialBase
    {
        public PlasticBase()
        {
        }
        public PlasticBase(string name) : base(name)
        {
        }
    }
}
