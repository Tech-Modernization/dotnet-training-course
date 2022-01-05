using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kata.CustomTypes.Kata.Recipe.Part7
{
    public class DishBase
    {
        protected List<Ingredient> ingreds = new List<Ingredient>();
        public string DishName { get; }
        public DishBase(string dishName)
        {
            DishName = dishName;
        }
        public override string ToString()
        {
            return $"DishBase({this.GetType().Name}): {DishName} \n    " + string.Join("\n   ", ingreds.Select(ing => ing.Name));
        }
    }
}
