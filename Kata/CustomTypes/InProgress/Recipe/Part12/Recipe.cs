using System;

namespace Kata.CustomTypes.Kata.Recipe.Part12
{
    public class Recipe<TDish> : IRecipeFollower
        where TDish : DishBase, new()
    {
        private TDish Dish;

        public Recipe()
        {
            Dish = new TDish();
        }
        public Recipe(TDish dish)
        {
            Dish = dish;
        }

        public void Follow()
        {
            Console.WriteLine($"Following {this}");
            foreach(var ing in Dish.Ingredients)
            {
                ing.Prepare();
            }
        }

        public override string ToString()
        {
            return $"Recipe instance for {Dish}";
        }

    }
}
