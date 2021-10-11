using System;
using System.Collections.Generic;
using System.Text;
using Kata.CustomTypes.MenuFactoryList;

namespace Kata.Demos
{
    public class MenuFactoryDemo : FactoryDemoBase<MenuBase, MenuItemBase>
    {
        public MenuFactoryDemo(params MenuBase[] concreteCreators) : base(concreteCreators)
        {
        }

        public override string ReadOnlyPropertyName => "Items";
        
    }
}
