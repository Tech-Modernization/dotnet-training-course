using System.Collections.Generic;

namespace PresentationLayer
{
    public interface IFactoryDemo<TAbstractCreator, TAbstractProduct>
    {
        bool CreatorProductRelationshipIsValid();
        List<TAbstractProduct> GetProducts<TConcreteCreator>(TConcreteCreator creator) where TConcreteCreator : TAbstractCreator;
    }
}
