using System;
using System.Collections.Generic;
using System.Text;

namespace Recipe
{
    public class Recipe<TDish> : IRecipeFollower<TDish>
        where TDish : DishBase, new()
    {
        public  TDish Dish { get; }

        public Recipe()
        {
            Dish = new TDish();
        }

        public void Follow()
        {
            Console.WriteLine("Starting to follow the {} recipe");
        }

        public Stage Process(Func<Ingredient[], Stage> anonProcess, params Ingredient[] ingredients)
        {
            if (anonProcess == null)
                return null;

            return anonProcess(ingredients);
        }

        public override string ToString()
        {
            return $"Following recipe for {Dish.DishName}";
        }
    }
}
