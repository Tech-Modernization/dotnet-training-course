namespace Kata.CustomTypes.MenuFactoryVariant
{
    public class DrinksMenu : MenuBase
    {
        protected override void CreateMenuItems()
        {
            Items.Add(new CoffeeMenuItemAdv());
           Items.Add(new WineMenuItem());
  //          Items.Add(new TeaMenuItem());
  //          Items.Add(new BeerMenuItem());
        }

        private class CoffeeMenuItemAdv : MenuItemBase
        {
            public override bool HasVariants { get; }
        }
    }
}
