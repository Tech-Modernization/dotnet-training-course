namespace Kata.CustomTypes.MenuFactoryVariant
{
    public class DrinkMenuItem : MenuItemBase
    {
        public override bool HasVariants { get => false; }
        protected string variantHeading;
    }
}
