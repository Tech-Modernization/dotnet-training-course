using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Kata.Services;
using Kata.DataServices;

namespace Kata.CustomTypes.Demo.Recipe.Part11
{
    public class DishBase : List<Ingredient>
    {
        protected IPantry Pantry;
        public string DishName { get; }

        public DishBase(string dishName)
        {
            DishName = dishName;
            Pantry = new Pantry(new CsvRecipeService(new FileDataService()));
        }

        public override string ToString()
        {
            return $"DishBase({this.GetType().Name}): {DishName} \n      " + string.Join("\n      ", this.Select(ing => ing.Name));
        }
    }
}
