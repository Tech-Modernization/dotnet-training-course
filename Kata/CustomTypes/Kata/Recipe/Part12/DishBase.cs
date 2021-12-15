using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kata.CustomTypes.Kata.Recipe.Part12
{
    public class DishBase : IDishBuilder
    {
        protected IPantry Pantry;
        protected List<Ingredient> Ingreds { get; }
        public Ingredient[] Ingredients => Ingreds.ToArray();
        public string DishName { get; }
        public DishBase(string dishName)
        {
            Pantry = new Pantry(new JsonRecipeService(new FileDataService()));
            Ingreds = new List<Ingredient>();
            DishName = dishName;
        }

        public override string ToString()
        {
            return $"DishBase({this.GetType().Name}): {DishName} \n      " 
                + string.Join("\n      ", Ingreds.Select(ing => ing.Name));
        }

        public virtual DishBuilderResult AddIngredient(string name, string amount)
        {
                    return DishBuilderResult.IngredientNotFound;
        }

        public virtual DishBuilderResult AddStage(string name, Stage stage)
        {
            throw new NotImplementedException();
        }
    }
}
