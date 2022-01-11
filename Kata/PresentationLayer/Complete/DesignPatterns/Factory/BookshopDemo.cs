using BusinessObjectLayer.BookshopFactory;
using BusinessObjectLayer.MediaFactory;
using System;

namespace PresentationLayer
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
