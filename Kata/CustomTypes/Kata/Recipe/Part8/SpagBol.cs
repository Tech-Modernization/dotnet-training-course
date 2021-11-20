using System;
using System.Collections.Generic;
using System.Linq;

namespace Kata.CustomTypes.Kata.Recipe.Part8
{
    public class SpagBol : DishBase
    {
        public SpagBol() : base("Spaghetti Bolognese")
        {
            Add(Pantry.Measure("spaghetti", "125g"));
            Add(Pantry.Measure("lloyd grossman sauce", "1 jar"));
        }
    }
}
