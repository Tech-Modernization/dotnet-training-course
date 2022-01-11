using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessObjectLayer.Recipe.Part6
{
    public class Recipe<TDish> : IRecipeFollower<TDish>
    {
        private TDish Dish;

        public Recipe(TDish dish)
        {
            Dish = dish;
        }

        public void Follow()
        {
            Console.WriteLine($"Following {this}");
        }

        public override string ToString()
        {
            return $"Recipe instance for dish: {Dish}";
        }
    }
}
