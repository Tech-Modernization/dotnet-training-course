namespace BusinessObjectLayer.Recipe.Part12
{
    public enum DishBuilderResult
    {
        IngredientAdded = 1,
        IngredientNotFound,
        AmbiguousIngredient,
        StageAdded,
        DuplicateStage,
        UnnamedStage,
        StageHasNoIngredients,
        DuplicateIngredient,
        IngredientDefined,
        IngredientsLoaded
    }
}