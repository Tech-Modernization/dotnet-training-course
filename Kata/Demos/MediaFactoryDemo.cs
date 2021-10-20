using System;
using System.Collections.Generic;
using System.Text;
using Kata.CustomTypes.MediaFactory;

namespace Kata.Demos
{
    public class MediaFactoryDemo : FactoryDemoBase<MediaCollectionBase, MediaItemBase>
    {
        protected override string ReadOnlyPropertyName => "Items";
        public MediaFactoryDemo(params MediaCollectionBase[] concreteCreators) : base(concreteCreators)
        {
        }

        public override void DisplayExplicit(MediaCollectionBase c)
        {
            throw new NotImplementedException();
        }

        public override void DisplayImplicit(MediaCollectionBase c)
        {
            throw new NotImplementedException();
        }
    }
}
