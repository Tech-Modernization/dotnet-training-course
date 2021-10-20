using System;
using System.Collections.Generic;
using System.Text;
using Kata.CustomTypes.MenuItemVariantFactory;

namespace Kata.Demos
{
    public class MenuItemFactoryDemo : FactoryDemoBase<MenuItemBase, MenuItemVariantBase>
    {
        protected override string ReadOnlyPropertyName => "Variants";
        public MenuItemFactoryDemo(params MenuItemBase[] concreteCreators) : base(concreteCreators)
        {
        }

        public override void DisplayExplicit(MenuItemBase c)
        {
            throw new NotImplementedException();
        }

        public override void DisplayImplicit(MenuItemBase c)
        {
            throw new NotImplementedException();
        }
    }
}
