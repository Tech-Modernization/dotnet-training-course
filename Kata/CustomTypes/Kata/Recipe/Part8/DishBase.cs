using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kata.CustomTypes.Kata.Recipe.Part8
{
    public class DishBase : List<Ingredient>
    {
        protected Pantry Pantry = new Pantry();
        public string DishName { get; }

        public DishBase(string dishName)
        {
            DishName = dishName;
        }

        public override string ToString()
        {
            return $"DishBase({this.GetType().Name}): {DishName} \n      " + string.Join("\n      ", this.Select(ing => ing.Name));
        }
    }
}
