using System;
using System.Collections.Generic;
using System.Text;

namespace Recipe
{
    public class Salad : DishBase
    {
        public Salad() : base("Salad")
        {
        }

        public string SaladName { get; }
    }
}
