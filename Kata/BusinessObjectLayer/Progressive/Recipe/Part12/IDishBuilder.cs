using System.Collections.Generic;

namespace BusinessObjectLayer.Recipe.Part12
{
    public interface IDishBuilder
    {
        DishBuilderResult DefineIngredient<TIngredient>(string name, string amount, List<string> altPrepSteps = null)
            where TIngredient : Ingredient;

        DishBuilderResult LoadIngredients();

        DishBuilderResult AddStage(string name, Stage stage);
    }
}