using System;
using System.Collections.Generic;
using System.Linq;

namespace Kata.Demos
{
    public class FactoryDemoBase<TAbstractCreator, TAbstractProduct> : IDemo, IFactoryDemo<TAbstractCreator, TAbstractProduct>
    {
        private List<TAbstractCreator> creators = new List<TAbstractCreator>();
        private string readonlyPropertyName;
        public virtual string ReadOnlyPropertyName { get => readonlyPropertyName; }
        
        public FactoryDemoBase(params TAbstractCreator[] concreteCreators)
        {
            readonlyPropertyName = $"{typeof(TAbstractProduct).Name.Replace("Base", "")}s";
            if (!CreatorProductRelationshipIsValid())
                throw new Exception($"Type {typeof(TAbstractCreator).Name} does not contain a property of List<{typeof(TAbstractProduct).Name}>");
            
            foreach (var c in concreteCreators)
            {
                creators.Add(c);
            }
        }

        public virtual void Run()
        {
            foreach(var c in creators)
            {
                Console.WriteLine(c);
                foreach(var p in GetProducts(c))
                {
                    Console.WriteLine(p);
                }
            }
        }

        public bool CreatorProductRelationshipIsValid()
        {
            var props = typeof(TAbstractCreator).GetProperties();
            var lists = props.Where(prop =>
            {
                var noSetter = !prop.CanWrite;
                var isList = prop.PropertyType.Name.StartsWith("List");
                var typeArg = prop.PropertyType.GenericTypeArguments.FirstOrDefault();
                var typeArgIsProduct = (typeArg?.FullName ?? "") == typeof(TAbstractProduct).FullName;
                return (noSetter && isList && typeArgIsProduct);
            })
                .ToList();
            return lists.Count == 1;
        }

        public List<TAbstractProduct> GetProducts<TConcreteCreator>(TConcreteCreator creator) where TConcreteCreator : TAbstractCreator
        {
            var propertyInfo = creator.GetType().GetProperty(ReadOnlyPropertyName);
            return (List<TAbstractProduct>)propertyInfo.GetValue(creator);
        }
    }
}
