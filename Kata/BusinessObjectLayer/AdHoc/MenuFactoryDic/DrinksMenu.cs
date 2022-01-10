namespace Kata.CustomTypes.MenuFactoryDic
{
    public class DrinksMenu : MenuBase
    {
        protected override void CreateMenuItems()
        {
            Items.Add(new CocaColaMenuItem());
            Items.Add(new CoffeeMenuItem());
        }
    }
}
