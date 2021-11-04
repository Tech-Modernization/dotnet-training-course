using System;
using System.Collections.Generic;
using System.Text;

namespace Kata.CustomTypes.RecyclingFactory
{
    public abstract class MaterialBase
    {
        public string Name { get; set; }

        public MaterialBase()
        {

        }
        public MaterialBase(string name)
        {
            Name = name;
        }
    }
}
