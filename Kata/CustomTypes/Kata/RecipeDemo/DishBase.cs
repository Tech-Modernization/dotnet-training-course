using System;
using System.Collections.Generic;
using System.IO;

using Kata.DataServices;


namespace Kata.CustomTypes.RecipeDemo
{
    public class DishBase : List<Ingredient>
    {
        public string DishName { get; }
        protected IPantry Pantry { get; }
        public DishBase()
        {
        }
        public DishBase(string dishName, IPantry pantry)
        {
            DishName = dishName;
            Pantry = pantry;
        }
    }
}
