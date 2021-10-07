namespace Kata.CustomTypes.MenuFactory
{
    public class DrinksMenu : MenuBase
    {
        protected override void CreateMenuItems()
        {
            Items.Add(new CoffeeMenuItem());
           Items.Add(new WineMenuItem());
  //          Items.Add(new TeaMenuItem());
  //          Items.Add(new BeerMenuItem());
        }
    }
}
