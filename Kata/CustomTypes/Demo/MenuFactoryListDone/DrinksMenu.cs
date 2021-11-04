namespace Kata.CustomTypes.MenuFactoryListDone
{
    public class DrinksMenu : MenuBase
    {
        protected override void CreateMenuItems()
        {
            var cokes = new DrinkMenuItem();
            cokes.Name = "Coca-Cola";
            cokes.AddVariant("Classic", SizeVariant.Half, 1.75M);
            cokes.AddVariant("Classic", SizeVariant.Pint, 2.5M);
            cokes.AddVariant("Diet", SizeVariant.Half, 1.75M);
            cokes.AddVariant("Diet", SizeVariant.Pint, 2.5M);
            cokes.AddVariant("Cherry", SizeVariant.Half, 2.25M);
            cokes.AddVariant("Cherry", SizeVariant.Pint, 3.0M);
            Items.Add(cokes);
            Items.Add(new CoffeeMenuItem());
        }
    }
}
