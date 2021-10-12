using System;
using System.Collections.Generic;
using System.Text;
using Kata.CustomTypes.MenuItemVariantFactory;

namespace Kata.Demos
{
    public class MenuItemFactoryDemo : FactoryDemoBase<MenuItemBase, MenuItemVariantBase>
    {
        public override string ReadOnlyPropertyName => "Variants";
        public MenuItemFactoryDemo(params MenuItemBase[] concreteCreators) : base(concreteCreators)
        {
        }
    }
}
