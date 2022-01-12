namespace Helpers
{
    public abstract class NumberValidator : IValidator<int>
    {
        public abstract bool IsValid(int arg);
    }
}
