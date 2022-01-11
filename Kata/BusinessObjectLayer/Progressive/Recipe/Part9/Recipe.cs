using System;

namespace BusinessObjectLayer.Recipe.Part9
{
    public class Recipe<TDish> : IRecipeFollower<TDish>
        where TDish : DishBase, new()
    {
        private TDish Dish;

        public Recipe()
        {
            Dish = new TDish();
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
