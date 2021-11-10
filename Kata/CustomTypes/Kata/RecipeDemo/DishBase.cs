using System;
using System.Collections.Generic;
using System.Text;

namespace Kata.CustomTypes.RecipeDemo
{
    public class DishBase : List<Ingredient>
    {
        protected Pantry Pantry { get; }
        public string DishName { get; }
        public DishBase(string dishName)
        {
            DishName = dishName;
            Pantry = new Pantry();
        }
    }
}
