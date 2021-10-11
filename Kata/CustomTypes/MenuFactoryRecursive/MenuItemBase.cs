
namespace Kata.CustomTypes.MenuFactoryRecursive
{
    public abstract class MenuItemBase
    {
        public string Name { get; set; }
        public SizeVariant Size { get; set; }
        public decimal Price { get; set; }
        public MenuBase SubMenu { get; set; }
    }
}
