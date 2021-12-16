using Kata.CustomTypes.Kata.Recipe.Part12;
using System;

namespace Kata.CustomTypes.Kata.Recipe.Part12Done
{
    public interface IDishBuilder
    {
        DishBuilderResult LoadIngredients();
        DishBuilderResult DefineIngredient<T>(string name, string amount, Action altPrep = null)
            where T : Ingredient;
        DishBuilderResult AddStage(string name, Stage stage);
    }
}