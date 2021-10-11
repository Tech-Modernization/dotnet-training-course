using System;
namespace Kata.CustomTypes.MenuFactoryList
{
    public abstract class MenuItemBase
    {
        public string Name { get; }
        public decimal Price { get; }
         
        public MenuItemBase(string name, decimal price)
        {
            Name = name;
            Price = price;
        }
    }
}
