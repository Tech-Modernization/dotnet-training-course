using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kata.CustomTypes.Kata.Recipe.Part15
{
    public class DishBase
    {
        protected List<Stage> Stages { get; }
        public string DishName { get; }
        public DishBase(string dishName)
        {
            DishName = dishName;
        }

        public override string ToString()
        {
            return DishName;
            // return $"DishBase({this.GetType().Name}): {DishName} \n      " + string.Join("\n      ", Ingreds.Select(ing => ing.Name));
        }
    }
}
