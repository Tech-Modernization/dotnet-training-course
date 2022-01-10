using System;

namespace Kata.CustomTypes.Kata.Recipe.Part7
{
    public class Recipe<TDish> : IRecipeFollower
        where TDish : DishBase, new()
    {
        private TDish Dish;

        public Recipe()
        {
            Dish = new TDish();
        }

        public void Follow()
        {
            Console.WriteLine($"TDish is a {typeof(TDish)}");
            Console.WriteLine($"Following {this}");
        }

        public override string ToString()
        {
            return $"Recipe instance for {Dish}";
        }

    }
}
