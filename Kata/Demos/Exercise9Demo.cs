using System;
using System.Collections.Generic;
using System.Text;
using Kata.CustomTypes.RecyclingFactoryDone;
/*
 * define an interface to manage a recycling plant.  you'll need methods to:

- direct the trucks to the correct silo for their material load (glass, plastic, etc)

- separate the different types of glass into stained glass, shatter glass, glassware, ceramics

- separate different types paper as for glass.  those types are arbitrary for illustration.

- clean stickers etc off the glass items

- crush cardboard boxes

- separate plastics

- melt plastics 

- unbag organic waste and put in composter

- dispose of organic waste bags in landfill silo.


the method signatures are all you have to write.  the types named are abitrary and you can use types that don't exist etc to get your concept across.
*/

namespace Kata.Demos
{
    public class Exercise9Demo : DemoBase
    {
        public void Run()
        {

        }
    }


    public interface IWasteProcessor
    {
        void Process(List<MaterialBase> items);
    }

    public interface ISiloManager
    {
        SiloBase GetSilo(MaterialBase material);
        void Deposit(List<MaterialBase> items, SiloBase silo);
    }

    public interface IWastePreparer<T>
    {
        Dictionary<T, List<MaterialBase>> Separate(List<MaterialBase> items);
        void Clean(List<MaterialBase> items);
    }

    public abstract class SiloBase
    {

    }
    public class Composter : SiloBase { }
    public class Landfill : SiloBase
    { }
    public class GlassSilo : SiloBase { }
    public class PlasticSilo : SiloBase { }
    public class CardboardSilo : SiloBase { }

    public enum GlassType {  Frosted, Cut, Yellow, Brown, Green };
    public enum OrganicComponent {  Bag, Waste };
    public enum PlasticType {  Milk, DrinkBottle, Moulded }
    public enum CardboardType {  Corrugated, Layered, Plain };

    public class GlassDept : IWastePreparer<GlassType>
    {
        public void Clean(List<MaterialBase> items)
        {
            foreach(var  i in items)
            {
                var glassItem = (GlassBase)i;
            }
        }

        public Dictionary<GlassType, List<MaterialBase>> Separate(List<MaterialBase> items)
        {
            var rv = new Dictionary<GlassType, List<MaterialBase>>();
            for(var gt = GlassType.Frosted; gt < GlassType.Green; gt++)
            {
                rv.TryAdd(gt, new List<MaterialBase>());

            }

            return rv;
        }
    }

}
