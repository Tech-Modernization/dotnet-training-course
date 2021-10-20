using System;
using System.Collections.Generic;
using System.Linq;

namespace Kata.Demos
{
    public enum Placement { Implicit, Explicit, Sample };
    public abstract class FactoryDemoBase<TAbstractCreator, TAbstractProduct> : IDemo, IFactoryDemo<TAbstractCreator, TAbstractProduct>
    {
        private List<TAbstractCreator> creators = new List<TAbstractCreator>();

        private string abstractProductName = typeof(TAbstractProduct).FullName;
        private string abstractCreatorName = typeof(TAbstractCreator).FullName;
        private string readonlyPropertyName;
        protected virtual string ReadOnlyPropertyName { get => readonlyPropertyName; }

        public Placement PlacementMode { get; set; }
        public bool IgnoreMiddleTier { get; set; }

        public virtual void FillExplicit(TAbstractCreator ac) { }
        public virtual void FillImplicit(Type ct, Type ap) { }
        public virtual void DisplayExplicit(TAbstractCreator ac) { }
        public virtual void DisplayImplicit(TAbstractCreator ac) { }

        public FactoryDemoBase(params TAbstractCreator[] concreteCreators)
        {
            readonlyPropertyName = $"{typeof(TAbstractProduct).Name.Replace("Base", "")}s";

            if (!CreatorProductRelationshipIsValid())
                throw new Exception($"Type {abstractCreatorName} does not contain a property of List<{abstractProductName}>");

            foreach (var c in concreteCreators)
            {
                creators.Add(c);
            }
        }

        public virtual void Run()
        {
            Console.WriteLine($"Running {this.GetType().Name}\nPlacement: {PlacementMode}"
                + $"\nMiddle tier: {(IgnoreMiddleTier ? "ignored" : "enabled")}");

            foreach (var c in creators)
            {
                Console.WriteLine(c);
                if (PlacementMode == Placement.Implicit)
                {
                    FillImplicit(c.GetType(), getAbstractProductType(c));
                    DisplayImplicit(c);
                    continue;
                }

                FillExplicit(c);
                DisplayExplicit(c);
            }
        }
        protected Type getAbstractProductType(TAbstractCreator c)
        {
            var propType = c.GetType().GetProperty(ReadOnlyPropertyName).PropertyType;
            return propType.GenericTypeArguments.FirstOrDefault();
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