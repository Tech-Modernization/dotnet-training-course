using System;
using System.Collections.Generic;
using System.Text;

using Kata.DataServices;

namespace Kata.CustomTypes.RecipeDemo
{
    public class Salad : DishBase
    {
        public Salad() : base("Salad")
        {
        }

        public string SaladName { get; }
    }
}
