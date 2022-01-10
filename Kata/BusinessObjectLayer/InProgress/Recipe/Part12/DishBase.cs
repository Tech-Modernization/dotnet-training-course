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

        public Dictionary<string, Func<string, Ingredient>> IngredientRegistry;
        public string DishName { get; }
        public DishBase(string dishName)
        {
            Pantry = new Pantry(new JsonRecipeService(new FileDataService()));
            Ingreds = new List<Ingredient>();
            IngredientRegistry = new Dictionary<string, Func<string, Ingredient>>();
            DishName = dishName;
        }

        public override string ToString()
        {
            return $"DishBase({this.GetType().Name}): {DishName} \n      " 
                + string.Join("\n      ", Ingreds.Select(ing => ing.Name));
        }


        public virtual DishBuilderResult AddStage(string name, Stage stage)
        {
            throw new NotImplementedException();
        }

        public DishBuilderResult DefineIngredient<TIngredient>(string name, string amount, List<string> altPrepSteps = null)
            where TIngredient : Ingredient
        {
            Action prepWrapper = () =>
            {
                foreach (var step in altPrepSteps)
                {
                    Console.WriteLine(step);
                }
            };

            Func<string, Ingredient> instantiator = (validName) =>
            {
                var newIng = Activator.CreateInstance(typeof(TIngredient), 
                    validName, amount, altPrepSteps == null ? null : prepWrapper) as Ingredient;
                return newIng;
            };

            var registered = IngredientRegistry.TryAdd(name, instantiator);
            return registered ? DishBuilderResult.IngredientDefined : DishBuilderResult.DuplicateIngredient;
        }

        public DishBuilderResult LoadIngredients()
        {
            foreach (var entry in IngredientRegistry)
            {
                var matches = Pantry.LookupIngredient(entry.Key);
                if (matches.Count != 1)
                {
                    return matches.Count == 0 ? DishBuilderResult.IngredientNotFound : DishBuilderResult.AmbiguousIngredient;
                }
                var ingred = entry.Value(matches.First());
                Ingreds.Add(ingred);
            }

            return DishBuilderResult.IngredientsLoaded;
        }
    }
}
