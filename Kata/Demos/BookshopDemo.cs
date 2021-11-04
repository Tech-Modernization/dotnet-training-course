using Kata.CustomTypes.BookshopFactory;
using Kata.CustomTypes.MediaFactory;
using System;

namespace Kata.Demos
{
    public class BookshopDemo : FactoryDemoBase<SectionBase, MediaItemBase>
    {
        public BookshopDemo(bool placementExplicit, params SectionBase[] concreteCreators) : base(concreteCreators)
        {
        }

        public override void FillExplicit(SectionBase ac)
        {
            throw new NotImplementedException();
        }
    }
}
