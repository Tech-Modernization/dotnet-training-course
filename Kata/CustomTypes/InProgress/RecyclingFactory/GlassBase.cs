using System;
using System.Collections.Generic;
using System.Text;

namespace Kata.CustomTypes.RecyclingFactory
{
    public class GlassBase : MaterialBase
    {
        public GlassBase()
        {
        }
        public GlassBase(string name) : base(name)
        {
        }
    }
}
