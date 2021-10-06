using DemoKata.CustomTypes;

namespace CustomTypes.MenuFactory
{
    public class DrinkMenu : MenuBase
    {
        protected override void CreateMenuItems()
        {
            Items.Add(new DrinkMenuItem(new Coffee()));
            Items.Add(new DrinkMenuItem());
            Items.Add(new DrinkMenuItem());
            Items.Add(new DrinkMenuItem());
        }
    }
}
