namespace Kata.CustomTypes.Kata.Recipe.Part12
{
    public enum DishBuilderResult
    {
        IngredientAdded = 1,
        IngredientNotFound,
        AmbiguousIngredient,
        StageAdded,
        DuplicateStage,
        UnnamedStage,
        StageHasNoIngredients
    }
}