using Kata.CustomTypes.Kata.Recipe.Part12;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kata.CustomTypes.Kata.Recipe.Part12Done
{
    public class DishBase : IDishBuilder
    {
        protected IPantry Pantry;
        protected Dictionary<string, Func<string, Ingredient>> IngredientRegistry;
        protected List<Ingredient> Ingreds { get; }
        public Ingredient[] Ingredients => Ingreds.ToArray();
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

        public DishBuilderResult LoadIngredients()
        {
            foreach (var kvp in IngredientRegistry)
            {
                var matches = Pantry.LookupIngredient(kvp.Key);
                if (matches.Count != 1)
                {
                    return matches.Count == 0 ? DishBuilderResult.IngredientNotFound : DishBuilderResult.AmbiguousIngredient;
                }
                var ingred = kvp.Value(matches.First());
                Ingreds.Add(ingred);
            }
            return DishBuilderResult.IngredientsLoaded;
        }

        public DishBuilderResult DefineIngredient<T>(string name, string amount, Action altPrep = null) where T : Ingredient
        {
            var added = IngredientRegistry.TryAdd(name, validName => (Ingredient) Activator.CreateInstance(typeof(T), validName, amount, altPrep));
            return added ? DishBuilderResult.IngredientDefined : DishBuilderResult.DuplicateIngredient;
        }
    }
}
