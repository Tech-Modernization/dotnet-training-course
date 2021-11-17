using System;
using System.Collections.Generic;
using System.Text;

namespace Recipe.Part7
{
    public class SpagBol : DishBase
    {
        public SpagBol() : base("Spaghetti Bolognese")
        {
            Add(new Ingredient("spaghetti", "125g"));
            Add(new Ingredient("lloyd grossman sauce", "1 jar"));
        }
    }
}
