using System;
using System.Collections.Generic;
using System.Linq;
using Kata.CustomTypes.RecyclingFactoryDone;

namespace Kata.Demos
{
    public class RecyclingFactoryDemo : FactoryDemoBase<ContainerBase, MaterialBase>
    {
        private List<ContainerBase> creators;
        private List<Type> botTypes = new List<Type>();
        

        public RecyclingFactoryDemo(params ContainerBase[] concreteCreators) : base(concreteCreators)
        {
            creators = new List<ContainerBase>(concreteCreators);
        }

       
        public override void DisplayExplicit(ContainerBase c)
        {
            Console.WriteLine($"{c.GetType().Name} - materials accepted:");
            foreach(var p in c.Materials)
            {
                Console.WriteLine($"    {p}");
            }
        }

        public override void DisplayImplicit(ContainerBase c)
        {
            var concreteName = c.GetType().FullName;
            var baseMat = concreteName.Replace("Container", "Base");
            var baseMatType = c.GetType().Assembly.GetType(baseMat);
            Console.WriteLine($"{concreteName} accepts: {baseMat}");
            foreach (var ap in c.GetType().Assembly.GetTypes().Where(t => typeof(MaterialBase).IsAssignableFrom(t)))
            {
                if (ap.BaseType == baseMatType)
                {
                    Console.WriteLine($"    {ap}");
                }
            }
        }

        public void GenerateWaste()
        {
            if (botTypes.Count == 0)
            {
                foreach (var t in typeof(ContainerBase).Assembly.DefinedTypes.Where(dt => typeof(MaterialBase) == dt.BaseType?.BaseType))
                {
                    botTypes.Add(t);
                }
            }

            var rand = new Random();
            var numItems = rand.Next(25, 50);
            do
            {
                var nextTypeIndex = rand.Next(0, botTypes.Count - 1);
                var nextType = botTypes[nextTypeIndex];
                var bin = findBin(nextType);
                Console.WriteLine(bin == null 
                    ? $"Unable to place {nextType.Name} using {PlacementMode} placement"
                    : $"{nextType.Name} goes in the {bin.Name}");
                
            } while (--numItems > 0);

        }

        Type findBin(Type materialChild)
        {
            var targetType = IgnoreMiddleTier ? materialChild : materialChild.BaseType;
            return PlacementMode == Placement.Implicit
                ? TypeMap.ContainsKey(targetType) ? TypeMap[targetType] : null
                : creators.SingleOrDefault(c => c.Materials.Any(m => targetType.IsAssignableFrom(m.GetType())))?.GetType();
        }

        public override void FillExplicit(ContainerBase cb)
        {
            cb.Materials.Clear();
            var rand = new Random();
            foreach(var cp in cb.GetType().Assembly.DefinedTypes.Where(t => typeof(MaterialBase) == t.BaseType))
            {
                if (cb.GetType().Name.Replace("Container", "") == cp.Name.Replace("Base", ""))
                {
                    var defTypes = cb.GetType().Assembly.DefinedTypes.Where(t => t.BaseType == cp).ToList();
                    var max = PlacementMode == Placement.Sample ? rand.Next(1, defTypes.Count) : defTypes.Count;
                    for(var i = max; i > 0; i--)
                    {
                        var botType = defTypes[i - 1];
                        cb.Materials.Add((MaterialBase) botType.Assembly.CreateInstance(botType.FullName));
                    }
                }
            }
        }

    }
}
