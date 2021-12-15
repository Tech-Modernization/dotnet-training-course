namespace Kata.CustomTypes.Kata.Recipe.Part12
{
    public interface IDishBuilder
    {
        DishBuilderResult AddIngredient(string name, string amount);
        DishBuilderResult AddStage(string name, Stage stage);
    }
}