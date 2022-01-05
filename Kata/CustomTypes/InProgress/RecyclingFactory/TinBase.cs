using System;
using System.Collections.Generic;
using System.Text;

namespace Kata.CustomTypes.RecyclingFactory
{
    public class TinBase : MaterialBase
    {
        public TinBase()
        {
        }
        public TinBase(string name) : base(name)
        {
        }
    }
}
