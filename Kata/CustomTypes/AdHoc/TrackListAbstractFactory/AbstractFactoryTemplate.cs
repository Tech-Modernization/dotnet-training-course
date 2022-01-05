using System;
using System.Collections.Generic;
using System.Text;

namespace CustomTypes.TrackListAbstractFactory
{
    class AbstractFactoryTemplate
    {
    }
    abstract class AlbumBase
    {
        public abstract VinylAlbum CreateVinylAlbum();
        public abstract CompactDiscAlbum CreateCompactDisc();
    }
    /// <summary>
    /// The 'ConcreteFactory1' class
    /// </summary>
    class SingleArtistAlbum : AlbumBase
    {
        public override VinylAlbum CreateVinylAlbum()
        {
            return new SingleArtistVinylAlbum();
        }
        public override CompactDiscAlbum CreateCompactDisc()
        {
            return new SingleArtistCompactDisc();
        }
    }
    /// <summary>
    /// The 'ConcreteFactory2' class
    /// </summary>
    class MultiArtistAlbum : AlbumBase
    {
        public override VinylAlbum CreateVinylAlbum()
        {
            return new MultiArtistVinylAlbum();
        }
        public override CompactDiscAlbum CreateCompactDisc()
        {
            return new MultiArtistCompactDisc();
        }
    }
    /// <summary>
    /// The 'AbstractProductA' abstract class
    /// </summary>
    abstract class VinylAlbum
    {
    }
    abstract class CompactDiscAlbum
    {
        public abstract void CompareFormats(VinylAlbum a);
    }
    class SingleArtistVinylAlbum : VinylAlbum
    {
    }
    class SingleArtistCompactDisc : CompactDiscAlbum
    {
        public override void CompareFormats(VinylAlbum a)
        {
            Console.WriteLine(this.GetType().Name +
              " interacts with " + a.GetType().Name);
        }
    }
    class MultiArtistVinylAlbum : VinylAlbum
    {
    }
    class MultiArtistCompactDisc : CompactDiscAlbum
    {
        public override void CompareFormats(VinylAlbum a)
        {
            Console.WriteLine(this.GetType().Name +
              " interacts with " + a.GetType().Name);
        }
    }
    class Client
    {
        private VinylAlbum _abstractProductA;
        private CompactDiscAlbum _abstractProductB;
        // Constructor
        public Client(AlbumBase factory)
        {
            _abstractProductB = factory.CreateCompactDisc();
            _abstractProductA = factory.CreateVinylAlbum();
        }
        public void Run()
        {
            _abstractProductB.CompareFormats(_abstractProductA);
        }
    }
}