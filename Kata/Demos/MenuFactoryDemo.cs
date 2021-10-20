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

        protected override string ReadOnlyPropertyName => "Items";

        public override void DisplayExplicit(MenuBase c)
        {
            throw new NotImplementedException();
        }

        public override void DisplayImplicit(MenuBase c)
        {
            throw new NotImplementedException();
        }
    }
}
