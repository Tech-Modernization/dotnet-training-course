using System;
using System.Collections.Generic;
using System.Linq;

using Kata.Services;
using Kata.DataServices;

namespace Kata.CustomTypes.Demo.Recipe.Part12
{
    public class DishBase : List<Ingredient>
    {
        protected IPantry Pantry;
        public string DishName { get; }

        public DishBase(string dishName)
        {
            DishName = dishName;
            Pantry = new Pantry(new JsonRecipeService(new FileDataService()));
        }

        public override string ToString()
        {
            return $"DishBase({this.GetType().Name}): {DishName} \n      " + string.Join("\n      ", this.Select(ing => ing.Name));
        }
    }
}
