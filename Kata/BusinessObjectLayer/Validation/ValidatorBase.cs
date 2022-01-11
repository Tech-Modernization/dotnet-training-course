
namespace BusinessObjectLayer.Validation
{

    public abstract class ValidatorBase<T> : IValidator
    {
        public abstract bool IsValid(T arg);
    }
}
