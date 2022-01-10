using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kata.CustomTypes.Kata.Recipe.Part9
{
    public class DishBase
    {
        protected Pantry Pantry = new Pantry();
        protected List<Ingredient> Ingreds { get; }
        public Ingredient[] Ingredients => Ingreds.ToArray();
           
        public string DishName { get; }

        public DishBase(string dishName)
        {
            Ingreds = new List<Ingredient>();
            DishName = dishName;
        }

        public override string ToString()
        {
            return $"DishBase({this.GetType().Name}): {DishName} \n      " + string.Join("\n      ", Ingreds.Select(ing => ing.Name));
        }
    }
}
