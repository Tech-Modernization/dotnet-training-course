using System;
using System.Collections.Generic;
using System.Text;

namespace Kata.CustomTypes.RecyclingFactory
{
    public class OrganicBase : MaterialBase
    {
        public OrganicBase()
        {
        }
        public OrganicBase(string name) : base(name)
        {
        }
    }
}
