using System;

namespace Kata.CustomTypes.Kata.Recipe.Part15
{
    public class Recipe : IRecipeFollower
    {
        private ICookBook cookbook;
        private DishBase Dish;
        
        public Recipe(ICookBook cookbook)
        {
            this.cookbook = cookbook;
        }

        public void Follow(string dishName)
        {
            Dish = cookbook.LoadDish(dishName);
            if (Dish == null)
            {
                Console.WriteLine($"No recipe found for dish: {dishName}");
                return;
            }

            Console.WriteLine($"Following {this}");
/*            foreach(var ing in Dish.Ingredients)
            {
                ing.Prepare();
            }
*/
        }

        public override string ToString()
        {
            return $"Recipe instance for {Dish}";
        }

    }
}
