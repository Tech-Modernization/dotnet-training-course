using System;
using System.Collections.Generic;
using System.Text;
using CustomTypes.MediaFactory;

namespace Kata.Demos
{
    public class MediaFactoryDemo : FactoryDemoBase<MediaCollectionBase, MediaItemBase>
    {
        public override string ReadOnlyPropertyName => "Items";
        public MediaFactoryDemo(params MediaCollectionBase[] concreteCreators) : base(concreteCreators)
        {
        }
    }
}
