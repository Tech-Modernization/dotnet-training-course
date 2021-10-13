using System;
using System.Collections.Generic;
using System.Text;
using Kata.CustomTypes.TrackListAbstractFactory;

namespace Kata.Demos
{
    public class TrackListFactoryDemo : FactoryDemoBase<AlbumFactoryBase, TrackListBase>
    {
        public TrackListFactoryDemo(params AlbumFactoryBase[] concreteCreators) : base(concreteCreators)
        {
        }
    }
}
